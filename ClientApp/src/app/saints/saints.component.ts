import { Component, OnInit } from '@angular/core';
import { Saint } from '../Models/saint';
import { SaintService } from '../Services/saint.service';

@Component({
  selector: 'app-saints',
  templateUrl: './saints.component.html'
})

export class SaintsComponent implements OnInit {

  saints: Saint[];

  favoriteSeason: string;
  orderBy: string[] = ['Born', 'Died', 'Beatified/Canonized'];

  constructor(private saintService: SaintService) { }

  ngOnInit(): void {
    this.loadSaints();
  }

  loadSaints() {
    this.saintService.getSaints().subscribe( saint => {
      this.saints = saint;
    }, error => {
      console.error('ERROR: ' + error.message);
    });
  }
}
