import { Component, OnInit } from '@angular/core';
import { MedicineService } from '../medicine.service';
import { Medicine } from '../Models/medicine';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import * as moment from 'moment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  medicines: Medicine[];
  constructor(private medicineService: MedicineService, private router: Router) {

  }
  ngOnInit(): void {
    this.medicineService.getMedicines().subscribe(
      x => this.medicines = x,
      () => { alert("Some error occured"); });
    }

  addMedicine() {
    this.router.navigate(["/add-update-medicine"]);
  }

  getColor(medicine: Medicine)  {

    if (medicine.quantity < 10)
      return 'yellow';

    var now = moment(new Date());
    var end = moment(medicine.expiryDate);

    var duration = moment.duration(end.diff(now));
    var days = duration.asDays();
    if (days < 30)
      return 'red';

  }
  
}
