/* -----------------------------------------------
/* How to use? : Check the GitHub README
/* ----------------------------------------------- */

/* To load a config file (particles.json) you need to host this demo (MAMP/WAMP/local)... */
/*
particlesJS.load('particles-js', 'particles.json', function() {
  console.log('particles.js loaded - callback');
});
*/

/* Otherwise just put the config content (json): */
particlesJS('particles-js',
  
  {
      "particles": {
          "number": {
              "value": 200,
              "density": {
                  "enable": true,
                  "value_area": 800
              }
          },
          "color": {
              "value": "#ffffff"
          },
          "shape": {
              "type": "circle",
              "stroke": {
                  "width": 1,
                  "color": "#ffffff"
              },
              "polygon": {
                  "nb_sides": 5
              },
              "image": {
                  "src": "img/github.svg",
                  "width": 100,
                  "height": 100
              }
          },
          "opacity": {
              "value": 0.8,
              "random": true,
              "anim": {
                  "enable": true,
                  "speed": 0.65,
                  "opacity_min": 0.1,
                  "sync": false
              }
          },
          "size": {
              "value": 8,
              "random": true,
              "anim": {
                  "enable": false,
                  "speed": 40,
                  "size_min": 0.1,
                  "sync": false
              }
          },
          "line_linked": {
              "enable": false,
              "distance": 500,
              "color": "#ffffff",
              "opacity": 0.4,
              "width": 2
          },
          "move": {
              "enable": true,
              "speed": 5,
              "direction": "top",
              "random": false,
              "straight": false,
              "out_mode": "out",
              "bounce": false,
              "attract": {
                  "enable": false,
                  "rotateX": 600,
                  "rotateY": 1200
              }
          }
      },
      "interactivity": {
          "detect_on": "canvas",
          "events": {
              "onhover": {
                  "enable": true,
                  "mode": "repulse"
              },
              "onclick": {
                  "enable": false,
                  "mode": "remove"
              },
              "resize": true
          },
          "modes": {
              "grab": {
                  "distance": 400,
                  "line_linked": {
                      "opacity": 0.5
                  }
              },
              "bubble": {
                  "distance": 400,
                  "size": 4,
                  "duration": 0.3,
                  "opacity": 1,
                  "speed": 3
              },
              "repulse": {
                  "distance": 100,
                  "duration": 0.4
              },
              "push": {
                  "particles_nb": 4
              },
              "remove": {
                  "particles_nb": 2
              }
          }
      },
      "retina_detect": true
  }
);