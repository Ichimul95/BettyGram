$(function () {
    var recognizing = false;
    var ignoreOnend;
    var mic = $("#mic");
    window.speechSynthesis.cancel();
    var pleaseRepeat = "Please repeat!";

    var objSpeak = new window.SpeechSynthesisUtterance();
    var recognition;
    var noResults;

    function speak(text, callback) {
        objSpeak.text = text;
        objSpeak.lang = "en-US";
        window.voices = window.speechSynthesis.getVoices();
        objSpeak.voice = window.voices[1];

        objSpeak.onstart = function (e) {
        };

        objSpeak.onend = function (e) {
            if (callback) {
                callback();
            }
        };

        objSpeak.onerror = function (e) {
            if (callback) {
                callback(e);
            }
        };
        window.speechSynthesis.speak(objSpeak);
    }

    function recognitionStarts() {
        noResults = true;
        recognition.lang = "en-US";
        recognition.start();
        ignoreOnend = false;
    }

    function playVideo(time) {
        $("#video1").get(0).currentTime = time;
        $("#video2").get(0).currentTime = time;
        $("#video3").get(0).currentTime = time;
        $("#video4").get(0).currentTime = time;
    }

    function pauseVideo() {
        $("#video1").get(0).pause();
        $("#video2").get(0).pause();
        $("#video3").get(0).pause();
        $("#video4").get(0).pause();
    }

    function changeVideoAndPlay(videoName) {
        var videoSrc = "/Content/Video/" + videoName;
        $("#video1").attr("src", videoSrc);
        $("#video2").attr("src", videoSrc);
        $("#video3").attr("src", videoSrc);
        $("#video4").attr("src", videoSrc);
        $("#video1").get(0).play();
        $("#video2").get(0).play();
        $("#video3").get(0).play();
        $("#video4").get(0).play();
    }

    function demo() {
        $(".fullwidth").removeClass("canvas-margin")
        $(".canvas1").hide(500);
        $(".canvas2").hide(500);
        $(".canvas3").hide(500);
        $(".canvas4").hide(500);

        window.setTimeout(function () {
            changeVideoAndPlay("hologramExemple.mp4");
        }, 2500);
    }

    function gallery() {
        $(".fullwidth").removeClass("canvas-margin")
        $(".canvas1").hide(500);
        $(".canvas2").hide(500);
        $(".canvas3").hide(500);
        $(".canvas4").hide(500);

        window.setTimeout(function () {
            changeVideoAndPlay("ColajEchipe.mp4");
        }, 2500);
    }



    function intro() {
        $(".fullwidth").removeClass("canvas-margin")
        $(".canvas1").hide(500);
        $(".canvas2").hide(500);
        $(".canvas3").hide(500);
        $(".canvas4").hide(500);

        $("#video1").get(0).play();
        $("#video2").get(0).play();
        $("#video3").get(0).play();
        $("#video4").get(0).play();
    }

    function menu() {
        $(".fullwidth").removeClass("canvas-margin")
        $(".canvas1").hide(500);
        $(".canvas2").hide(500);
        $(".canvas3").hide(500);
        $(".canvas4").hide(500);

        $("#video1").attr("src", "/Content/Video/ActualOptionsFinal.mp4");
        $("#video2").attr("src", "/Content/Video/ActualOptionsFinal.mp4");
        $("#video3").attr("src", "/Content/Video/ActualOptionsFinal.mp4");
        $("#video4").attr("src", "/Content/Video/ActualOptionsFinal.mp4");

        $("#placeholder1").hide(500);
        $("#placeholder2").hide(500);
        $("#placeholder3").hide(500);
        $("#placeholder4").hide(500);

        $("#video1").show(500);
        $("#video2").show(500);
        $("#video3").show(500);
        $("#video4").show(500);

        $("#video1").attr("loop", "true");
        $("#video2").attr("loop", "true");
        $("#video3").attr("loop", "true");
        $("#video4").attr("loop", "true");

        $("#video1").get(0).play();
        $("#video2").get(0).play();
        $("#video3").get(0).play();
        $("#video4").get(0).play();
    }

    function presentation() {
        $(".fullwidth").removeClass("canvas-margin")
        $("#video1").attr("src", "/Content/Video/hi_2.mp4");
        $("#video2").attr("src", "/Content/Video/hi_2.mp4");
        $("#video3").attr("src", "/Content/Video/hi_2.mp4");
        $("#video4").attr("src", "/Content/Video/hi_2.mp4");

        $("#placeholder1").hide(500);
        $("#placeholder2").hide(500);
        $("#placeholder3").hide(500);
        $("#placeholder4").hide(500);

        $("#video1").show(500);
        $("#video2").show(500);
        $("#video3").show(500);
        $("#video4").show(500);

        $("#video1").attr("loop", "true");
        $("#video2").attr("loop", "true");
        $("#video3").attr("loop", "true");
        $("#video4").attr("loop", "true");

        $("#video1").get(0).play();
        $("#video2").get(0).play();
        $("#video3").get(0).play();
        $("#video4").get(0).play();

        speak( "Nice to meet you. Here is what I can do for you: I can tell you the weather, nice images from Stabiplan, tell you the company values and even make a calculation in Stabicad" );
    }

    function company() {
        $(".weather").hide();
        $(".fullwidth").addClass("canvas-margin")
        $(".canvas1").show(500);
        $(".canvas2").show(500);
        $(".canvas3").show(500);
        $(".canvas4").show(500);

        mic.attr("style", "margin-bottom: 0; margin-top: 100px");
        pauseVideo();

        $("#video1").hide(500);
        $("#video2").hide(500);
        $("#video3").hide(500);
        $("#video4").hide(500);

        var ctx = document.getElementById("myChart");
        var myChart1 = new Chart("myChart-1", {
            type: 'bar',
            data: {
                labels: ["October", "November", "December", "January", "February", "March"],
                datasets: [{
                    data: [12, 19, 5, 56, 20, 7],
                    backgroundColor: [
                        'rgb(255, 77, 255)',
                        'rgb(0, 204, 0)',
                        'rgb(0, 57, 230)',
                        'rgb(255, 255, 0)',
                        'rgb(77, 0, 153)',
                        'rgb(255, 51, 0)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
        });

        var myChart2 = new Chart("myChart-2", {
            type: 'bar',
            data: {
                labels: ["October", "November", "December", "January", "February", "March"],
                datasets: [{
                    data: [12, 19, 5, 56, 20, 7],
                    backgroundColor: [
                        'rgb(255, 77, 255)',
                        'rgb(0, 204, 0)',
                        'rgb(0, 57, 230)',
                        'rgb(255, 255, 0)',
                        'rgb(77, 0, 153)',
                        'rgb(255, 51, 0)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
        });

        var myChart3 = new Chart("myChart-3", {
            type: 'bar',
            data: {
                labels: ["October", "November", "December", "January", "February", "March"],
                datasets: [{
                    label: '# of Votes',
                    data: [12, 19, 5, 56, 20, 7],
                    backgroundColor: [
                        'rgb(255, 77, 255)',
                        'rgb(0, 204, 0)',
                        'rgb(0, 57, 230)',
                        'rgb(255, 255, 0)',
                        'rgb(77, 0, 153)',
                        'rgb(255, 51, 0)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
        });

        var myChart4 = new Chart("myChart-4", {
            type: 'bar',
            data: {
                labels: ["October", "November", "December", "January", "February", "March"],
                datasets: [{
                    data: [12, 19, 5, 56, 20, 7],
                    backgroundColor: [
                        'rgb(255, 77, 255)',
                        'rgb(0, 204, 0)',
                        'rgb(0, 57, 230)',
                        'rgb(255, 255, 0)',
                        'rgb(77, 0, 153)',
                        'rgb(255, 51, 0)'
                    ],
                    borderColor: [
                        'rgba(255,99,132,1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
        });
        // };

        $("#placeholder1").show(500);
        $("#placeholder2").show(500);
        $("#placeholder3").show(500);
        $("#placeholder4").show(500);
    }

    function weather() {
        $(".fullwidth").removeClass("canvas-margin")
        $(".canvas1").hide(500);
        $(".canvas2").hide(500);
        $(".canvas3").hide(500);
        $(".canvas4").hide(500);  

        window.setTimeout(function () {
            mic.attr("style", "margin-bottom: 0; margin-top: 100px");

            pauseVideo();

            $("#video1").hide(500);
            $("#video2").hide(500);
            $("#video3").hide(500);
            $("#video4").hide(500);

            $.ajax({
                url: "/Home/Weather/",
                type: "Get",

                success: function (data) {
                    var html = "<div class='weather'><h3>" + data.values.weather[0].main + "<h3>";
                    html += "<p><strong>Description: </strong>" + data.values.weather[0].description + "<img src='http://openweathermap.org/img/w/" + data.values.weather[0].icon + ".png'><p>";
                    html += "<p><strong>Temperature: </strong>" + data.values.main.temp + "°C<p>";
                    html += "<p><strong>Humidity: </strong>" + data.values.main.humidity + "<p>";
                    html += "<p><strong>Wind speed: </strong>" + data.values.wind.speed + "<p></div>";

                    $("#placeholder1").html(html);
                    $("#placeholder2").html(html);
                    $("#placeholder3").html(html);
                    $("#placeholder4").html(html);
                }
            });

            $("#placeholder1").show(500);
            $("#placeholder2").show(500);
            $("#placeholder3").show(500);
            $("#placeholder4").show(500);
        }, 2500);
    }

    if ("webkitSpeechRecognition" in window) {
        recognition = new window.webkitSpeechRecognition();
        var whiteList = ["home", "company", "values", "value", "weather", "hologram", "menu", "next", "demo", "photo", "photos", "options", "option", "culture", "presentation", "identity"];
        var grammar = "#JSGF V1.0; public <keyword> = home|company|values|value|weather|calculation|menu|demo|photo|photos|options|option|culture|presentation|identity;";
        var speechRecognitionList = new window.webkitSpeechGrammarList();
        speechRecognitionList.addFromString(grammar, 1);
        recognition.grammars = speechRecognitionList;
        recognition.maxAlternatives = 1;

        recognition.continuous = false;
        recognition.interimResults = false;
        noResults = true;

        recognition.onstart = function () {
            recognizing = true;
        };

        recognition.onerror = function (event) {
            if (event.error === "no-speech") {
                console.log("info_no_speech");
                ignoreOnend = true;
            }
            if (event.error === "audio-capture") {
                console.log("info_no_microphone");
                ignoreOnend = true;
            }
            if (event.error === "not-allowed") {
                console.log("info_denied");
                ignoreOnend = true;
            }
        };
        recognition.onend = function () {
            recognizing = false;
            recognitionStarts();

            if (ignoreOnend) {
                return;
            }
        };
        recognition.onnomatch = function () {
            speak(pleaseRepeat);
        }

        recognition.onresult = function (event) {
            var len = event.results.length;
            if (len === 0) {
                speak(pleaseRepeat);
                return;
            }
            mic.attr("style", "border: #00ff00 2px solid");
            for (var i = event.resultIndex; i < len; ++i) {
                if (event.results[i].isFinal) {
                    var keyword = event.results[i][0].transcript;
                    for (var wordInx = 0; wordInx < whiteList.length; wordInx++) {
                        var option = whiteList[wordInx];
                        if (keyword.indexOf(option) !== -1) {
                            var message = "Let's see the " + option;
                            if (option === "menu") {
                                message = "Ofcourse";
                            }
                            speak(message);
                            switch (option) {
                                case "home":
                                    intro();
                                    break;
                                case "presentation":
                                case "identity":
                                    presentation();
                                    break;
                                case "menu":
                                case "option":
                                case "options":
                                    menu();
                                    break;
                                case "weather":
                                    playVideo(3);
                                    window.setTimeout(function () {
                                        changeVideoAndPlay("ChoseWeatherFinal.mp4");
                                    }, 500);
                                    weather();
                                    break;
                                case "hologram":
                                    playVideo(4);
                                    window.setTimeout(function () {
                                        changeVideoAndPlay("ChoseDemoFinal.mp4");
                                    }, 500);
                                    demo();
                                    break;
                                case "demo":
                                    playVideo(4);
                                    window.setTimeout(function () {
                                        changeVideoAndPlay("ChoseDemoFinal.mp4");
                                    }, 500);
                                    demo();
                                    break;
                                case "photos":
                                case "photo":
                                    playVideo(4);
                                    window.setTimeout(function () {
                                        changeVideoAndPlay("ChosePhotoFinal.mp4");
                                    }, 500);
                                    gallery();
                                    break;
                                case "company":
                                case "value":
                                case "values":
                                    //playVideo(5);
                                    window.setTimeout(function () {
                                        changeVideoAndPlay("ChoseValuesFinal.mp4");
                                    }, 500);
                                    company();
                                    
                                    speak("Here are the sales of the company.");
                                    break;
                            }
                            noResults = false;
                            break;
                        }
                    }
                }
            }
        };
    }

    recognitionStarts();

    intro();
    window.setTimeout(function () {
        speak("Hi! I am Bethy. What can I do for you?");
    }, 9000);
});
