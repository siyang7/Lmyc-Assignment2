import { Component, OnInit } from '@angular/core';
import { Boat, BoatService } from '../boat.service';
import { ReservationsService } from '../reservation.service';
import { Router } from '@angular/router';
import { Reservation } from '../reservation';

@Component({
  selector: 'app-make-reservations',
  templateUrl: './make-reservations.component.html',
  styleUrls: ['./make-reservations.component.css']
})
export class MakeReservationsComponent implements OnInit {

  public boats: Boat[] = [];
  public startDateT: Date = new Date();
  public endDateT: Date = new Date();
  public selectedBoat: string = null;

  constructor(private boatService: BoatService, private reservationsService: ReservationsService, private router: Router) { }

  ngOnInit() {
    this.boatService.GetBoats().then(r => {
      this.boats = r;
    });
  }

  createReservation() {
    if (this.selectedBoat == null)
      return;

    let r: Reservation = new Reservation();

    r.startDateTime = this.startDateT.toLocaleString();
    r.endDateTime = this.endDateT.toLocaleString();
    r.boatId = parseInt(this.selectedBoat);

    this.reservationsService.CreateReservation(r).then(r => {
      this.router.navigate(["/reservations"]);
    })
  }
}
