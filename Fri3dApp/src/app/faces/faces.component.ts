import { Component, OnInit } from '@angular/core';
import {Observable} from 'rxjs/Rx';

import { Face, FaceDTO } from '../face';
import { FACES } from '../faces';
import { FaceService } from './faces.service'
import { HttpErrorResponse } from '@angular/common/http';
import {MatDialog, MatDialogConfig,MatDialogModule } from '@angular/material';
import { AuthorizationDialog } from './authorizationcode/dialog.component';
@Component({
  selector: 'app-faces',
  templateUrl: './faces.component.html',
  styleUrls: ['./faces.component.css']
})

export class FacesComponent implements OnInit {
 
  faces = FACES;
 
  selectedface: Face;
  authorizationCode: number;
  constructor(private _faceService: FaceService, public dialog: MatDialog) { }
 
  ngOnInit() {
  }
  openDialog(face:Face): void {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.data = {
      name: face.name
  };
    let dialogRef = this.dialog.open(AuthorizationDialog,dialogConfig);


    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      let faceDTO = new FaceDTO(face.id, this.authorizationCode);
    this._faceService.requestFace(faceDTO).subscribe(
             data => {
               return true;
             },
             error => {
               console.error("Error saving food!");
               return Observable.throw(error);
             });
    });
  }
  onSelect(face: Face): void {
    this.openDialog(face);
    
  }
}