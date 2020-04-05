document.getElementById("Exit").addEventListener("click", ExitClick);

function ExitClick(){
  self.close()
}

// Functions for the drop down menus Sector selection
// sector 1 on click
document.getElementById("Sector_0").onclick = function(){
    var x = document.getElementById("sector_num");
    x.innerHTML = "0";
}

// sector 1 on click
document.getElementById("Sector_1").onclick = function(){
    var x = document.getElementById("sector_num");
    x.innerHTML = "1";
}

// sector 2 on click
document.getElementById("Sector_2").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "2";
}

// sector 3 on click
document.getElementById("Sector_3").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "3";
}

// sector 4 on click
document.getElementById("Sector_4").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "4";
}

// sector 5 on click
document.getElementById("Sector_5").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "5";
}

// sector 6 on click
document.getElementById("Sector_6").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "6";
}

// sector 7 on click
document.getElementById("Sector_7").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "7";
}

// sector 8 on click
document.getElementById("Sector_8").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "8";
}

// sector 9 on click
document.getElementById("Sector_9").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "9";
}

// sector 10 on click
document.getElementById("Sector_10").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "10";
}

// sector 11 on click
document.getElementById("Sector_11").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "11";
}

// sector 12 on click
document.getElementById("Sector_12").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "12";
}

// sector 13 on click
document.getElementById("Sector_13").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "13";
}

// sector 14 on click
document.getElementById("Sector_14").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "14";
}

// sector 15 on click
document.getElementById("Sector_15").onclick = function(){
  var x = document.getElementById("sector_num");
  x.innerHTML = "15";
}


/* When the user clicks on the button,
toggle between hiding and showing the dropdown content */
function DropDownMenu() {
    document.getElementById("myDropdown").classList.toggle("show");
}

// Close the dropdown menu if the user clicks outside of it
window.onclick = function(event) {
    if (!event.target.matches('.dropbtn')) {
        var dropdowns = document.getElementsByClassName("dropdown-content");
        var i;
        for (i = 0; i < dropdowns.length; i++) {
          var openDropdown = dropdowns[i];
          if (openDropdown.classList.contains('show')) {
            openDropdown.classList.remove('show');
          }
        }
      }
    }
