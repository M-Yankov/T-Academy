import { Component, Injectable, OnInit, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute } from '@angular/router';
import { Movie } from '../../models/movie';

@Component({
    selector: 'movie-details',
    templateUrl: './movie-detail-component.html',
    styleUrls: ['./movie-detail-component.css']
})
@Injectable()
export class MovieDetailCompoent implements OnInit, OnDestroy {

    model: Movie = new Movie();
    private observable: any;
    constructor(
        private http: Http,
        private route: ActivatedRoute) {
    }

    ngOnInit() {
        this.observable = this.route.params.subscribe(params => {

            let title = params['title'];

            this.http.get(`http://www.omdbapi.com/?t=${title}`).subscribe(res => {
                this.model = res.json();
            });
        });

    }

    ngOnDestroy() {
        this.observable.unsubscribe();
    }
}
