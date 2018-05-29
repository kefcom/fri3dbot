import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { FacesComponent } from './faces/faces.component';
import { FaceService } from './faces/faces.service';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogModule, MatFormFieldModule } from '@angular/material';
import { AuthorizationDialog } from './faces/authorizationcode/dialog.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    FacesComponent,    
    AuthorizationDialog
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    MatDialogModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule
  ],
  providers: [FaceService],
  bootstrap: [AppComponent],
  entryComponents: [AuthorizationDialog]
})
export class AppModule { }
