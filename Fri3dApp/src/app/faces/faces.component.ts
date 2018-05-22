import { Component, OnInit } from '@angular/core';
import { Face } from '../face';
import { FACES } from '../faces';

@Component({
  selector: 'app-faces',
  templateUrl: './faces.component.html',
  styleUrls: ['./faces.component.css']
})

export class FacesComponent implements OnInit {
 
  faces = FACES;
 
  selectedface: Face;
  
  constructor() { }
 
  ngOnInit() {
  }
 
  onSelect(face: Face): void {
    this.selectedface = face;
  }
}