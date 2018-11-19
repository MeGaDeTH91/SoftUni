let assert = require('chai').assert;
let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
let $ = require("jquery");

let nuke = require("../armagedom").nuke;

describe("ArmageDOMTests", function () {
    let oldHtml;
    let htmlSelector;

    beforeEach("Initialize HTML", function () {
        document.body.innerHTML =
            `<div id="target">
                <div class="nested target">
                    <p>This is some text</p>
                </div>
                <div class="target">
                    <p>Empty div</p>
                </div>
                <div class="inside">
                    <span class="nested">Some more text</span>
                    <span class="target">Some more text</span>
                </div>
            </div>`;

        htmlSelector = $('#target');
        oldHtml = htmlSelector.html();
    });
    before(()=>global.$ = $);
    
    it("EqualSelectorsShouldReturnNull", function () {
        nuke(".nested", ".nested");
        assert.equal(htmlSelector.html(), oldHtml);
    });
    it("InvalidSelectorShouldReturnNull", function () {
        nuke(htmlSelector, 5);
        assert.equal(htmlSelector.html(), oldHtml);
    });
    it("ValidSelectorsShouldReturnNull", function () {
        nuke($('.inside'), $('.nested'));
        assert.equal(htmlSelector.html(), oldHtml);
    });
    it("ValidSelectorsShouldRemoveElements", function () {
        let selector1 = $('.nested');
        let selector2 = $('.target');
        nuke(selector1, selector2);
        assert.notEqual(htmlSelector.html(), oldHtml);
    });
});