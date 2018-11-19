let assert = require('chai').assert;
let SoftUniFy = require('../app');

describe("SoftUniFyAllTests", function() {
    let mySoftUniFy;
    beforeEach(function () {
        mySoftUniFy = new SoftUniFy();
    });
    describe("InitializeTests", function() {
        it("ShouldCreateWithEmptyObject", function() {
            let actual = typeof(mySoftUniFy.allSongs);
            let expected = typeof({});

            assert.equal(actual, expected);
        });
        it("ShouldCreateWithEmptyObjectZero", function() {
            let actual = Object.keys(mySoftUniFy.allSongs).length;
            let expected = 0;

            assert.equal(actual, expected);
        });
    });

    describe("DownloadSongTests",function () {
       it("NewArtistShouldInitialize", function () {
          mySoftUniFy.downloadSong("Megadeth", "Hangar18", "TooLong");
          let actualRate = mySoftUniFy.allSongs["Megadeth"]["rate"];
          let actualVotes = mySoftUniFy.allSongs["Megadeth"]["votes"];

          let expectedRate = 0;
          let expectedVotes = 0;

          assert.equal(actualRate, expectedRate);
          assert.equal(actualVotes, expectedVotes);
       });
        it("NewArtistShouldInitialize", function () {
            mySoftUniFy.downloadSong("Megadeth", "Hangar18", "TooLong");
            let actual = mySoftUniFy.allSongs["Megadeth"]["songs"][0];
            let expected = "Hangar18 - TooLong";

            assert.equal(actual, expected);
        });
        it("NewArtistShouldInitializeChaining", function () {
            mySoftUniFy.downloadSong("Megadeth", "Hangar18", "TooLong").downloadSong("Megadeth", "Hangar19", "TooLong");
            let actual = mySoftUniFy.allSongs["Megadeth"]["songs"][1];
            let expected = "Hangar19 - TooLong";

            assert.equal(actual, expected);
        });
    });
    describe("PlaySongTests", function () {
       it("EmptyCollectionShouldReturnMessage", function () {
           let actual = mySoftUniFy.playSong("Hangar18");
           let expected = "You have not downloaded a Hangar18 song yet. Use SoftUniFy's function downloadSong() to change that!";

           assert.equal(actual, expected);
       });
        it("OneSongShouldPlayIt", function () {
            mySoftUniFy.downloadSong("Megadeth", "Hangar18", "TooLong");
            let actual = mySoftUniFy.playSong("Hangar18");
            let expected = "Megadeth:\nHangar18 - TooLong\n";

            assert.equal(actual, expected);
        });
    });
    describe("GetSongListTests", function () {
        it("GetSongsWithNoSongsShouldReturnMessage", function () {
            let actual = mySoftUniFy.songsList;
            let expected = "Your song list is empty";

            assert.equal(actual, expected);
        });
        it("GetSongsWithTwoSongsShouldWorkCorrectly", function () {
            mySoftUniFy.downloadSong("Megadeth", "Hangar18", "TooLong").downloadSong("Megadeth", "Hangar19", "TooLong");
            let actual = mySoftUniFy.songsList;
            let expected = "Hangar18 - TooLong\nHangar19 - TooLong";

            assert.equal(actual, expected);
        });
    });
    describe("RateArtistTests", function () {
        it("RateArtistWithNoArtistShouldReturnMessage", function () {
            mySoftUniFy.downloadSong("Megadeth", "Hangar18", "TooLong");
            let actual = mySoftUniFy.rateArtist("Johny");
            let expected = "The Johny is not on your artist list.";

            assert.equal(actual, expected);
        });
        it("RateArtistWithValidArtistShouldReturnResult", function () {
            mySoftUniFy.downloadSong("Megadeth", "Hangar18", "TooLong");
            mySoftUniFy.rateArtist("Megadeth", 2);
            mySoftUniFy.rateArtist("Megadeth", 3);
            mySoftUniFy.rateArtist("Megadeth", 6);

            let actualVotes = mySoftUniFy.allSongs["Megadeth"]["votes"];
            let actualRate = mySoftUniFy.rateArtist("Megadeth");
            let expected = 3.67;

            assert.equal(actualRate, expected);
        });
        it("RateArtistWithValidArtistCheckVotes", function () {
            mySoftUniFy.downloadSong("Megadeth", "Hangar18", "TooLong");
            mySoftUniFy.rateArtist("Megadeth", 2);
            mySoftUniFy.rateArtist("Megadeth", 3);
            mySoftUniFy.rateArtist("Megadeth", 6);

            let actualVotes = mySoftUniFy.allSongs["Megadeth"]["votes"];
            let expected = 3;

            assert.equal(actualVotes, expected);
        });
    });
});
