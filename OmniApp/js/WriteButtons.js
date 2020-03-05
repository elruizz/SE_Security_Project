document.getElementById("clear").addEventListener("click", ClearClick);
document.getElementById("write").addEventListener("click", WriteClick);
document.getElementById("exit").addEventListener("click", ExitClick);




function ClearClick(){

        alert("Hello")
        // Do some shit yo
}

function WriteClick(){

    // Read some card
}

function ExitClick(){
    
    self.close()
}

/* When the user clicks on the button,
toggle between hiding and showing the dropdown content */
function myFunction() {
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