function solve() {
    var module = (function () {

        var playable,
            audio,
            video,
            player,
            playlist,
            validator,
            CONSTANT;

        CONSTANT = {
            MAX_TEXT_LENGTH: 25,
            MIN_TEXT_LENGTH: 3,
            MIN_RATING: 1,
            MAX_RATING: 5 // in IMDB max score is 10.
        };

        validator = {
            validateString: function (textToValidate) {
                if (typeof textToValidate != 'string' || textToValidate === undefined) {
                    throw new Error('This is not a string!');
                }

                if (textToValidate.length < CONSTANT.MIN_TEXT_LENGTH || CONSTANT.MAX_TEXT_LENGTH < textToValidate.length) {
                    throw new Error('Length must be between ' + CONSTANT.MIN_TEXT_LENGTH + ' and ' + CONSTANT.MAX_TEXT_LENGTH);
                }
            },
            validateNumber: function (aNumber) {
                if (typeof aNumber !== 'number' || aNumber === undefined) {
                    throw new Error('Not a Number!');
                }

                if (aNumber <= 0) {
                    throw new Error('Number must be greater than zero!');
                }
            },
            validateRating: function (rating) {
                if (typeof rating !== 'number' || rating === undefined) {
                    throw new Error('Not a Number from rating!');
                }

                if (rating < CONSTANT.MIN_RATING || CONSTANT.MAX_RATING < rating) {
                    throw new Error('Rating must be between ' + CONSTANT.MIN_RATING + ' and ' + CONSTANT.MAX_RATING + '!');
                }
            },

            validateIsPlayable: function (value) {
                if (value.id === undefined && value.title === undefined && value.author === undefined) {
                    throw new Error('Not a playable Object.');
                }
            },

            validatePlaylist: function (playlist) {
                if (playlist.id === undefined && playlist.name === undefined) {
                    throw new Error('Not a playlist!');
                }
            }
        };

        /* Construct Playable */

        playable = (function () {

            var currentPlayableId = 0,
                playable = Object.create({});
            Object.defineProperties(playable, {
                init: {
                    value: function (title, author) {
                        this.title = title;
                        this.author = author;
                        this.id = ++currentPlayableId;
                        return this;
                    }
                },

                // encapsulation
                id: {
                    get: function () {
                        return this._id;
                    },
                    set: function (value) {
                        validator.validateNumber(value);
                        this._id = value;
                    }
                },

                title: {
                    get: function () {
                        return this._title;
                    },
                    set: function (value) {
                        validator.validateString(value);
                        this._title = value;
                    }
                },

                author: {
                    get: function () {
                        return this._author;
                    },
                    set: function (value) {
                        validator.validateString(value);
                        this._author = value;
                    }
                },

                play: {
                    value: function () {
                        return this.id + '. ' + this.title + ' - ' + this.author;
                    }
                }
            });
            return playable
        }());

        /* Construct Audio */

        audio = (function (playableAsParent) {
            var audio = Object.create(playableAsParent);

            Object.defineProperties(audio, {
                init: {
                    value: function (title, author, length) {
                        playableAsParent.init.call(this, title, author);
                        this.length = length;
                        return this;
                    }
                },

                length: {
                    get: function () {
                        return this._length;
                    },
                    set: function (value) {
                        validator.validateNumber((value));
                        this._length = value;
                    }
                },

                play: {
                    value: function () {
                        return playableAsParent.play.call(this) + ' - ' + this.length;
                    }
                }
            });

            return audio;
        }(playable));

        /* Construct Video `*/

        video = (function (playableAsParent) {
            var video = Object.create(playableAsParent);

            Object.defineProperties(video, {
                init: {
                    value: function (title, author, rating) {
                        playableAsParent.init.call(this, title, author);
                        this.imdbRating = rating;
                        return this;
                    }
                },
                imdbRating: {
                    get: function () {
                        return this._imdbRating
                    },
                    set: function (value) {
                        validator.validateRating(value);
                        this._imdbRating = value;
                    }
                },
                play: {
                    value: function () {
                        return playableAsParent.play.call(this) + ' - ' + this.imdbRating;
                    }
                }
            });
            return video;
        }(playable));

        /* Construct Playlist */

        playlist = (function () {
            function indexOfPlayable(searchForID, playables) {
                var i,
                    len = playables.length;
                for (i = 0; i < len; i += 1) {
                    if (playables[i].id == searchForID) {
                        return i;
                    }
                }
                return null;
            }

            function validateListPLayables(page, size, length) {
                if (page < 0) {
                    throw new Error('Page must be greater than or equal to 0!');
                }

                if (size <= 0) {
                    throw new Error('Size must be greater than 0!');
                }

                if (length < page * size) {
                    throw new Error('Not enough playables in collection!');
                }
            }

            var playlist = Object.create({}),
                currentIdOfPlaylist = 0;

            Object.defineProperties(playlist, {
                init: {
                    value: function (name) {
                        this.name = name;
                        this.id = ++currentIdOfPlaylist;
                        this.playables = [];
                        return this;
                    }
                },

                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validator.validateString(value);
                        this._name = value;
                    }
                },

                addPlayable: {
                    value: function (playable) {
                        validator.validateIsPlayable(playable);
                        this.playables.push(playable);
                        return this;
                    }
                },

                getPlayableById: {
                    value: function (id) {
                        validator.validateNumber(id);
                        var index = indexOfPlayable(id, this.playables);
                        if (typeof  index === 'number') {

                            return this.playables[index];
                        }
                        return index; // or null;
                    }
                },

                removePlayable: {
                    value: function (value) {
                        var searchedId,
                            index;
                        if (typeof value === 'object' && typeof value.id === 'number') {
                            searchedId = value.id;
                        } else {
                            validator.validateNumber(value);
                            searchedId = value;
                        }

                        index = indexOfPlayable(searchedId, this.playables);
                        if (index === null) {
                            throw new Error('To remove playable - enter a existing id!');
                        } else {
                            this.playables.splice(index, 1);
                            return this;
                        }
                    }
                },

                listPlayables: {
                    value: function (page, size) {
                        var results,
                            length = this.playables.length;
                        validateListPLayables(page, size, length);
                        results = this.playables.slice().splice(page * size, size);

                        // Sorting is first capital letters then small letters.
                        results.sort(function (firstElement, secondElement) {
                            if (firstElement.title > secondElement.title) {
                                return 1;
                            } else if (firstElement.title < secondElement.title) {
                                return -1;
                            }

                            if (firstElement.id > secondElement.id) {
                                return 1;
                            } else if (firstElement.id < secondElement.id) {
                                return -1;
                            } else {
                                return 0;
                            }
                        });

                        return results;
                    }
                }
            });

            return playlist;
        }());

        /* Construct Player */

        player = (function () {
            var playerID = 0,
                player = Object.create({});

            function indexOfPlaylist(id, playlists) {
                var i,
                    len = playlists.length;
                for (i = 0; i < len; i += 1) {
                    if (playlists[i].id === id) {
                        return i;
                    }
                }
                return null;
            }

            function validateListPlaylists(page, size, length) {
                if (page < 0) {
                    throw new Error('Page must be greater than or equal to 0!');
                }

                if (size <= 0) {
                    throw new Error('Size must be greater than 0!');
                }

                if (length < page * size) {
                    throw new Error('Not enough playables in collection!');
                }
            }

            Object.defineProperties(player, {
                init: {
                    value: function (name) {
                        validator.validateString(name);
                        this.name = name;
                        this.id = ++playerID;
                        this.playlists = [];
                        return this;
                    }
                },

                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validator.validateString(value);
                        this._name = value;
                    }
                },

                addPlaylist: {
                    value: function (playlist) {
                        validator.validatePlaylist(playlist);
                        this.playlists.push(playlist);
                        return this;
                    }
                },

                getPlaylistById: {
                    value: function (id) {
                        validator.validateNumber(id);
                        var index = indexOfPlaylist(id, this.playlists);
                        if (index === null) {
                            return index; // or null;
                        }
                        return this.playlists[index];
                    }
                },

                removePlaylist: {
                    value: function (id) {
                        validator.validateNumber(id);
                        var index = indexOfPlaylist(id, this.playlists);
                        if (index === null) {
                            throw new Error('No such ID in playlist');
                        }
                        this.playlists.splice(index, 1);
                        return this;
                    }
                },

                listPlaylists: {
                    value: function (page, size) {
                        var results,
                            length = this.playlists.length;
                        validateListPlaylists(page, size, length);
                        results = this.playlists.slice().splice(page * size, size);

                        // Sorting is first capital letters then small letters.
                        results.sort(function (firstElement, secondElement) {
                            if (firstElement.name > secondElement.name) {
                                return 1;
                            } else if (firstElement.name < secondElement.name) {
                                return -1;
                            }

                            if (firstElement.id > secondElement.id) {
                                return 1;
                            } else if (firstElement.id < secondElement.id) {
                                return -1;
                            } else {
                                return 0;
                            }
                        });

                        return results;
                    }
                },

                contains: {
                    value: function (playable, playlist) {
                        validator.validateIsPlayable(playable);
                        validator.validatePlaylist(playlist);
                        var i,
                            playableslength = playlist.playables.length;

                        for (i = 0; i < playableslength; i += 1) {
                                if (playlist.playables[i].id === playable.id &&
                                    playlist.playables[i].title === playable.title &&
                                    playlist.playables[i].author === playable.author) {
                                    return true;
                                }
                        }
                        return false;
                    }
                },

                search: {
                    value: function (pattern) {
                        // what type is pattern
                        var i,
                            j,
                            playablesLength,
                            result = [],
                            myPattern = pattern.toLowerCase(),
                            playlistsLength = this.playlists.length;
                        for (i = 0; i < playlistsLength; i += 1) {
                            playablesLength = this.playlists[i].playables.length;
                            for (j = 0; j < playablesLength; j += 1) {
                                if(this.playlists[i].playables[j].title.toLowerCase().indexOf(myPattern) != -1 &&
                                    this.playlists[i].playables[j].length !== undefined &&
                                    this.playlists[i].playables[j].imdbRating === undefined){
                                    result.push({
                                        name: this.playlists[i].name,
                                        id: this.playlists[i].id
                                    });
                                    break;
                                }
                            }
                        }
                        return result;
                    }
                }
            });
            return player;
        }());
        return {
            getPlayer: function (name) {
                return Object.create(player).init(name);
            },
            getPlaylist: function (name) {
                return Object.create(playlist).init(name);
            },
            getAudio: function (title, author, length) {
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function (title, author, imdbRating) {
                return Object.create(video).init(title, author, imdbRating);
            }
        }
    }());
    return module;
}

var myModule = solve();
var i, name, playlist;
name = 'Hard Rock';
playlist = myModule.getPlaylist(name);

for (i = 0; i < 35; i += 1) {
    playlist.addPlayable({id: (i + 1), name: 'Rock' + (9 - (i % 10))});
}

console.log(playlist.listPlayables(2, 10).length);  // 10

console.log(playlist.listPlayables(3, 10).length);  // 5);

//playlist.listPlayables(-1, 10); //throw
//playlist.listPlayables(5, 10);
//playlist.listPlayables(1, -1);