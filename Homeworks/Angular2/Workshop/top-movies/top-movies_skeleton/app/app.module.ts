import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { Ng2BootstrapModule } from 'ng2-bootstrap';

import { routes } from './app.routes';
import { AppComponent } from './app.component';
import {
    MoviesListComponent,
    MovieCompoent,
    MovieDetailCompoent,
    HeaderComponent,
    FooterComponent,
    AcStar,
    AcStars
} from './core/components/';

import { SortPipe } from './core/pipes/sort-pipe';

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        MoviesListComponent,
        MovieCompoent,
        MovieDetailCompoent,
        HeaderComponent,
        FooterComponent,
        AcStar,
        AcStars,
        SortPipe],
    imports: [
        HttpModule,
        BrowserModule,
        Ng2BootstrapModule,
        FormsModule,
        routes]
})
export class AppModule { }
