var Image = {
    init: function (title, tumbnailURL, largeURL) {
        this.title = title;
        this.tumbnailURL = tumbnailURL;
        this.largeURL = largeURL;
    }
};

var Button = {
    init: function (id, title) {
        this.id = id;
        this.title = title;
    }
};

var Slider = {
    init: function (setOfImages, previusButton, nextButton) {
        this.setOfImages = setOfImages;
        this.siteImages = this.createImgs();
        this.previysButton = previusButton;
        this.nextButton = nextButton;
        this.currentPosition = 0;
    },
    createImgs: function () {
        var siteImages = [];
        for (var i = 0; i < this.setOfImages.length; i++) {
            var image = document.createElement("img");
            image.src = this.setOfImages[i].tumbnailURL;
            image.alt = this.setOfImages[i].title;
            image.className = "sliderImg";
            siteImages[i] = image;
        }

        return siteImages;
    },
    initialiseImgs: function () {
        for (var i = 0; i < this.siteImages.length; i++) {
            if (this.siteImages[i + 1]) {
                this.siteImages[i + 1].style.display = "none";
            }
            document.body.appendChild(this.siteImages[i]);
        }
    },
    next: function () {
        var list = document.getElementsByClassName("sliderImg");

        for (var i = 0; i < list.length; i++) {

            if (list[i].style.display != "none") {
                list[i].style.display = "none";
                if (i + 1 < list.length) {
                    list[i + 1].style.display = "inline-block";
                    break;
                }
                else {
                    list[0].style.display = "inline-block";
                    break;
                }
            }
        }
    },
    previus: function () {
        var list = document.getElementsByClassName("sliderImg");
        for (var i = 0; i < list.length; i++) {

            if (list[i].style.display != "none") {
                list[i].style.display = "none"
                if (i - 1 >= 0) {
                    list[i - 1].style.display = "inline-block";
                    break;
                }
                else {
                    list[list.length - 1].style.display = "inline-block";
                    break;
                }
            }
        }
    },
    initialiseButtons: function () {
        var previusButton = document.createElement("a");
        previusButton.innerHTML = this.previysButton.title;
        previusButton.id = this.previysButton.id;
        previusButton.href = "#";
        document.body.appendChild(document.createElement("br"));
        document.body.appendChild(previusButton);
        previusButton.onclick = this.previus;
        var siteNextButton = document.createElement("a");
        siteNextButton.innerHTML = this.nextButton.title;
        siteNextButton.id = this.nextButton.id;
        siteNextButton.href = "#";
        siteNextButton.onclick = this.next;
        document.body.appendChild(siteNextButton);
    }
};

var SliderControler = {
    init: function (slider) {
        this.slider = slider;
    },
    start: function () {
        this.slider.initialiseImgs();
        this.slider.initialiseButtons();
    },
}