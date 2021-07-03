import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm } from '@angular/forms';
import { Saint } from '../Models/saint';
import { AdminService } from '../Services/admin.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html'
})
export class AdminComponent implements OnInit {
  
  name = new FormControl('');
  biography = new FormControl('');
  pictureUrl = new FormControl('');
  quote = new FormControl('');
  
  constructor(private adminService: AdminService) { }
  
  ngOnInit() {
  }
  
  sendSaint() {

    let saint : Saint = {
      "name" : this.name.value,
      "biography" : this.biography.value,
      "pictureUrl" : this.pictureUrl.value,
      "quote" : this.quote.value
    }

    this.adminService.sendSaint(saint).subscribe(next => {}, error => {
      console.error(error);
    });
  }

  deleteSaint(f: NgForm, name: string) {
      this.adminService.deleteSaint(name).subscribe(next => {}, error => {
        console.error(error);
      });
    }
}
