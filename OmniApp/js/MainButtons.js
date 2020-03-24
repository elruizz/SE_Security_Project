document.getElementById("Exit").addEventListener("click", ExitClick);

function ExitClick(){
  self.close()
}

// Functions for the drop down menus Sector selection

// sector 1 on click
document.getElementById("Sector_1").onclick = function(){
    alert("Hi")
    //TODO ADD SWITCHING OF SECTOR FROM ONE TO ANOTHER
}
  
// sector 2 on click
document.getElementById("Sector_2").onclick = function(){alert("Hi")}
  
// sector 3 on click
document.getElementById("Sector_3").onclick = function(){alert("Hi")}
  
// sector 4 on click
document.getElementById("Sector_4").onclick = function(){alert("Hi")}
  
// sector 5 on click
document.getElementById("Sector_5").onclick = function(){alert("Hi")}
  
// sector 6 on click
document.getElementById("Sector_6").onclick = function(){alert("Hi")}
  
// sector 7 on click
document.getElementById("Sector_7").onclick = function(){alert("Hi")}
  
// sector 8 on click
document.getElementById("Sector_8").onclick = function(){alert("Hi")}
  
// sector 9 on click
document.getElementById("Sector_9").onclick = function(){alert("Hi")}
  
// sector 10 on click
document.getElementById("Sector_10").onclick = function(){alert("Hi")}

// sector 11 on click
document.getElementById("Sector_11").onclick = function(){alert("Hi")}
  
// sector 12 on click
document.getElementById("Sector_12").onclick = function(){alert("Hi")}
  
// sector 13 on click
document.getElementById("Sector_13").onclick = function(){alert("Hi")}
  
// sector 14 on click
document.getElementById("Sector_14").onclick = function(){alert("Hi")}
  
// sector 15 on click
document.getElementById("Sector_15").onclick = function(){alert("Hi")}
  

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
