import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-get-boats',
  templateUrl: './get-boats.component.html',
  styleUrls: ['./get-boats.component.css']
})
export class GetBoatsComponent {
  public boats: Boat[];
  public lmycUrl = "https://localhost:44309/";

  constructor(http: HttpClient) {
    http.get<Boat[]>(this.lmycUrl + 'api/BoatsAPI').subscribe(result => {
      this.boats = result;
    }, error => console.error(error));
  }
}

interface Boat {
  boatId: number;
  boatName: string;
  picture: string;
  lengthInFeet: number;
  make: string;
  year: number;
  creationDate: string;
  applicationUserId: string;
  applicationUser: string;
}
