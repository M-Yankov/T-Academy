export class Movie {

    Title: String;      //  "The Shawshank Redemption",
    Year: Number;       // "1994",
    Rated: String;      //  "R",
    Released: Date;     //  "14 Oct 1994",
    Runtime: String;    // "142 min",
    Genre: String;      // "Crime, Drama",
    Director: String;   // "Frank Darabont",
    // Writer: "Stephen King (short story \"Rita Hayworth and Shawshank Redemption\"), Frank Darabont (screenplay)",
    // Actors: "Tim Robbins, Morgan Freeman, Bob Gunton, William Sadler",
    // Plot: "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency.",
    // Language: "English",
    // Country: "USA",
    // Awards: "Nominated for 7 Oscars. Another 19 wins & 30 nominations.",
    Poster: String; // "https://images-na.ssl-images-amazon.com/images/M/MV5BODU4MjU4NjIwNl5BMl5BanBnXkFtZTgwMDU2MjEyMDE@._V1_SX300.jpg",
    // Metascore: "80",
    imdbRating: Number; // "9.3",
    // imdbVotes: "1,738,596",
    // imdbID: "tt0111161",
    // Type: "movie",
    // Top250: "1"

    constructor(title?: String, year?: Number, poster?: String, rating?: Number) {
        this.Title = title;
        this.Year = year;
        this.Poster = poster;
        this.imdbRating = rating;
    }
}
