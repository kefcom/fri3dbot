import { Component, OnInit } from '@angular/core';
import { Face } from '../face';
import { FACES } from '../faces';

@Component({
  selector: 'app-faces',
  templateUrl: './faces.component.html',
  styleUrls: ['./faces.component.css']
})

export class FacesComponent implements OnInit {
  face: Face = {
    id: 1,
    name: 'Windstorm'
  };
  faces = FACES;

  constructor() { }

  ngOnInit() {
  }

}
