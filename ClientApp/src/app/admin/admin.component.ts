import { Component, OnInit } from "@angular/core";
import { FormControl, NgForm } from "@angular/forms";
import { Saint } from "../Models/saint";
import { AdminService } from "../Services/admin.service";
import { MatSnackBar } from "@angular/material/snack-bar";

@Component({
  selector: "app-admin",
  templateUrl: "./admin.component.html",
})
export class AdminComponent implements OnInit {
  name = new FormControl("");
  biography = new FormControl("");
  pictureUrl = new FormControl("");
  quote = new FormControl("");

  durationInSeconds = 3;

  constructor(
    private adminService: AdminService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit() {}

  sendSaint() {
    let saint: Saint = {
      name: this.name.value,
      biography: this.biography.value,
      pictureUrl: this.pictureUrl.value,
      quote: this.quote.value,
    };

    this.adminService.sendSaint(saint).subscribe(
      () => {
        this._snackBar.open("Saint Added", null, {
          duration: this.durationInSeconds * 1000,
        });
        this.name.reset();
        this.biography.reset();
        this.pictureUrl.reset();
        this.quote.reset();
      },
      (error) => {
        console.error(error);
      }
    );
  }

  deleteSaint(f: NgForm, name: string) {
    this.adminService.deleteSaint(name).subscribe(
      () => {
        this._snackBar.open("Saint Deleted", null, {
          duration: this.durationInSeconds * 1000,
        });
      },
      (error) => {
        this._snackBar.open(error.message, null, {
          duration: this.durationInSeconds * 1000,
        });
        console.error(error.message);
      });
      
      f.reset()
  }
}
