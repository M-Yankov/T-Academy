import { Component, OnInit, OnDestroy } from '@angular/core';
import { Http, HttpModule, Response } from '@angular/http';
import { Movie } from '../../models/movie';
import { SortPipe } from '../../pipes/sort-pipe';
import { RemoteUrl } from '../../constants';

@Component({
    selector: 'movies-list',
    templateUrl: './movies-list.component.html',
})

export class MoviesListComponent implements OnInit, OnDestroy {
    movies: Movie[] = [];
    cacheMovies: Movie[] = [];
    private pipeSort: SortPipe = new SortPipe();
    defaultTitle: string = 'Batman';

    private observable: any;

    constructor(private http: Http) { }

    ngOnInit() {
        // async!!!

        this.observable = this.http.get(`${RemoteUrl}?s=${this.defaultTitle}`)
            .map((r: Response) => { return r.json(); })
            .subscribe((jsonMovies: any) => {
                this.movies = jsonMovies.Search;
                this.cacheMovies = this.movies.slice();
                this.pipeSort.transform(this.movies, 'Year', false);
            });
    }

    filterMovies(title: string, sort: string, order: string) {

        console.log('start filter');
        this.movies = this.cacheMovies.filter((e: Movie) => {
            if (e.Title.toLowerCase().indexOf(title.toLowerCase()) !== -1) {
                return e;
            }

            return null;
        });


        let orderValue: boolean;
        if (order === 'asc') {
            orderValue = true;
        } else {
            orderValue = false;
        }

        this.pipeSort.transform(this.movies, sort, orderValue);

        console.log('finish filter');
    }

    ngOnDestroy() {
        this.observable.unsubscribe();
    }

}
