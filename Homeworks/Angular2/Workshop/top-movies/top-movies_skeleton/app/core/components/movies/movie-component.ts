import { Component, Input } from '@angular/core';
import { Movie } from '../../models/movie';

@Component({
    selector: '[movie]',
    templateUrl: './movie-component.html'
})
export class MovieCompoent {
    @Input() movieItem: Movie;

    constructor() {
    }
}