import { Component, OnInit } from '@angular/core';
import { ReservationsService } from '../reservation.service';
import { Reservation } from '../reservation';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.css']
})
export class ReservationsComponent implements OnInit {

  public reservations: Array<Reservation> = [];

  constructor(private reservationService: ReservationsService) { }

  ngOnInit() {
    this.reservationService.GetReservations()
      .then(r => {
        this.reservations = r;
      }).catch(r => {
        alert("Error getting reservations: " + r);
      });
  }
}