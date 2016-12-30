import { Routes, RouterModule } from '@angular/router';
import { MoviesListComponent } from './core/components/movies/movies-list.component';
import { MovieDetailCompoent } from './core/components/movies/movie-detail-component';

const appRoutes: Routes = [
    { path: '', component: MoviesListComponent },
    { path: ':title/details', component: MovieDetailCompoent },
    { path: '**',  redirectTo: ''}
];

export const routes = RouterModule.forRoot(appRoutes);
