import { Component, OnInit } from '@angular/core';
import { Saint } from '../Models/saint';

@Component({
  selector: 'app-saints',
  templateUrl: './saints.component.html'
})



export class SaintsComponent implements OnInit {

  saints: Saint[];

  constructor() { }

  ngOnInit(): void {
  }

}
