import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MakeReservationsComponent } from './make-reservations/make-reservations.component';
import { ReservationsComponent } from './reservations/reservations.component';
import { AccountService } from './account.service';
import { BoatService } from './boat.service';
import { ReservationsService } from './reservation.service';

const appRoutes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'reservations',
    component: ReservationsComponent
  },
  {
    path: 'makeReservations',
    component: MakeReservationsComponent
  },
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MakeReservationsComponent,
    ReservationsComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpModule,
    HttpClientModule,
  ],
  providers: [AccountService, BoatService, ReservationsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
