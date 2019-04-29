import { Component, OnInit } from '@angular/core';
import { MedicineService } from '../medicine.service';
import { Medicine } from '../Models/medicine';
import { RouterLink, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import * as moment from 'moment';

@Component({
  selector: 'app-add-or-update',
  templateUrl: './add-or-update.component.html',
  styleUrls: ['./add-or-update.component.css']
})
export class AddOrUpdateComponent implements OnInit {

  constructor(private medicineService: MedicineService, private Router: Router, private formBuilder: FormBuilder) {
   
  }
  formlabel: string = 'Add Medicine';
  addForm: FormGroup;
  btnvisibility: boolean = true;
  ngOnInit() {

    this.buildForm();
  }

  buildForm() {

    this.addForm = this.formBuilder.group({
      name: ['', Validators.required],
      brand: ['', Validators.required],
      price: [0,],
      quantity: ['', [Validators.required, Validators.min(1)]],
      expirydate: ['', Validators.required],
      note: ['']
    });

  }


  AddMedidine() {
      

    var expiray = moment(this.addForm.value.expirydate, 'YYYY-MM-DD').toDate();

    let expiray1 = moment(expiray).startOf('day');

    

    let medicine: Medicine = {


      brand: this.addForm.value.brand,
      expiryDate: expiray,
      name: this.addForm.value.name,
      note: this.addForm.value.note,
      price: this.addForm.value.price,
      quantity: this.addForm.value.quantity
    };
    this.medicineService.addMedicine(medicine).subscribe(
      () => {
        alert("Medicine added");
        this.buildForm();

      },
      () => { alert("Medicine already exist") }
    )
  }

  UpdateMedicine(medicine: Medicine) {
    this.medicineService.updateMedicine(medicine).subscribe(
      () => {
        alert("Medicine updated");       
      },
      () => { alert("Failed to update medicine"); }
    )
  }

  goBack() {
    this.Router.navigate(["/"]);
  }

}
