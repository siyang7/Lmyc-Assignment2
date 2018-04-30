import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from './../environments/environment';
import { AccountService } from './account.service';
import { BoatService } from './boat.service';
import { Reservation } from './reservation';

@Injectable()
export class ReservationsService {
  private reservationURL: string;

  constructor(private client: HttpClient, private accountService: AccountService) {
    this.reservationURL = environment.localUrl + "reservations/";
  }

  public GetReservations(): Promise<Reservation[]> {
    return new Promise<Reservation[]>((resolve, reject) => {

      this.client.get(this.reservationURL
        //,this.accountService.getHttpHeaderOptions()
      )
        .toPromise()
        .then((resultSet: any) => {
            //list of reservations.
            resolve(resultSet as (Reservation[]));

      }).catch(r => {
        reject(r);
      });
    });
  }
  
  public CreateReservation(resv: Reservation): Promise<boolean> {
    resv.userId = resv.id = undefined;

    return new Promise<boolean>((resolve, reject) => {
      this.client.post(this.reservationURL, resv,
        this.accountService.getHttpHeaderOptions()).toPromise()
        .then(r => {
          resolve(true);

      }).catch(r => {
        reject(r);
      });
    });
  }

}