import { Component, OnInit } from "@angular/core";
import { FormControl, NgForm } from "@angular/forms";
import { Saint } from "../Models/saint";
import { SaintService } from "../Services/saint.service";
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
  status = new FormControl("");

  durationInSeconds = 3;

  saint: Saint;
  searchSaint = new FormControl("");

  constructor(
    private saintService: SaintService,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit() {}

  getSaint() {
    this.saintService.getSaint<Saint>(this.searchSaint.value).subscribe(saint => 
      this.saint = saint
    )
  }

  sendSaint() {

    this.saintService.sendSaint(this.saint).subscribe(
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

  updateSaint() {
    this.saintService.updateSaint(this.saint).subscribe (
      () => {},
      (error) => console.log(error)
    )
  }

  deleteSaint(f: NgForm, name: string) {
    this.saintService.deleteSaint(name).subscribe(
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
