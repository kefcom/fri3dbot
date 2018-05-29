import {Component, Inject, OnInit} from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';


import {FormBuilder, Validators, FormGroup} from "@angular/forms";
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { Face } from '../../face';

@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: './dialog.component.html',
})
export class AuthorizationDialog  implements OnInit {

    form: FormGroup;
    name:string;

    constructor(
      private fb: FormBuilder,
      private dialogRef: MatDialogRef<AuthorizationDialog>,
      @Inject(MAT_DIALOG_DATA) {name}:Face ) {

      this.name = name;


      this.form = fb.group({
          code: ['', Validators.required]
      });

  }
  ngOnInit() {

  }

    save() {
        this.dialogRef.close(this.form.value);
    }

    close() {
        this.dialogRef.close();
    }

}