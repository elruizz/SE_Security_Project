document.getElementById("Exit").addEventListener("click", ExitClick);

// Write block buttons listeners
document.getElementById("Button-Write-Block-0").onclick = writeBlock0;
document.getElementById("Button-Write-Block-1").onclick = writeBlock1;
document.getElementById("Button-Write-Block-2").onclick = writeBlock2;
document.getElementById("Button-Write-Block-3").onclick = writeBlock3;

// Read block buttons listeners
document.getElementById("Button-Read-Block-0").onclick = readBlock0;
document.getElementById("Button-Read-Block-1").onclick = readBlock1;
document.getElementById("Button-Read-Block-2").onclick = readBlock2;
document.getElementById("Button-Read-Block-3").onclick = readBlock3;

// Exit the application
function ExitClick(){
  self.close()
}

// Write functions
function writeBlock0(){
  var Block = getBlocknum(0);
  alert(Block);
}

function writeBlock1(){
  var Block = getBlocknum(1);
  alert(Block);
}

function writeBlock2(){
  var Block = getBlocknum(2);
  alert(Block);
}

function writeBlock3(){
  var Block = getBlocknum(3);
  alert(Block);
}

// Read functions
function readBlock0(){
  var Block = getBlocknum(0);
  alert(Block);
}

function readBlock1(){
  var Block = getBlocknum(1);
  alert(Block);
}

function readBlock2(){
  var Block = getBlocknum(2);
  alert(Block);
}

function readBlock3(){
  var Block = getBlocknum(3);
  alert(Block);
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


// get hex block number
function getBlocknum(num) {
  var sector = document.getElementById("sector_num");
  var secNum = sector.innerHTML;
  var Block;
  if (secNum == 0){
      Block = num
  }
  else {
    Block = ((secNum * 4))+ num;
  }
  var hexString = Block.toString(16);

  return hexString

}