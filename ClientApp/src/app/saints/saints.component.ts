import { Component, Input, OnInit } from '@angular/core';
import { MatRadioGroup, MatRadioChange, MatRadioButton } from '@angular/material/radio';
import { MsalService } from '@azure/msal-angular';
import { Order } from '../Enums/Order';
import { Saint } from '../Models/saint';
import { SaintService } from '../Services/saint.service';

@Component({
  selector: 'app-saints',
  templateUrl: './saints.component.html'
})

export class SaintsComponent implements OnInit {

  saints: Saint[];

  labels: string[] = ['Name', 'birthDate', 'deathYear', 'latestEvent'];
  orderby: string;
  selSaint: Saint;

  popTrue: boolean = false;


  constructor(private saintService: SaintService, private authService: MsalService) { }

  ngOnInit(): void {
    this.orderby = this.labels[3];
    this.loadSaints(this.orderby, Order.Descending);
  }
  
  deleteButton() {
    let accounts = this.authService.instance.getAllAccounts();
  }

  loadSaints(property: string, order: Order) {
    this.saintService.getSaints(property, order.toString()).subscribe(saint => {
      this.saints = saint;
    }, error => {
      console.error('ERROR: ' + error.message);
    });
  }

  openTheBox(setTo: boolean, name: string) {
    this.popTrue = setTo;
    this.selSaint = this.saints.find(s => s.name === name);
    }

  closeTheBox(setTo: boolean) {
    this.popTrue = setTo;
  }

  // requestOrderedBy() {
  //   this.saintService.getSaints(this.orderby).subscribe()
  // }
}
