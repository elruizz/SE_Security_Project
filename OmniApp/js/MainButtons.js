// var request = new XMLHttpRequest();
// request.open('GET', 'http://localhost:8080/test/');
// request.onload= function()
var path = require('path');
var edge = require('electron-edge-js');
//export for our js file to use for the serve

// Adding exit button functionality
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

// Clear log
document.getElementById("Clear-Log").onclick = clearLog;

//Import Edge Functions
var appLoadKey = edge.func({
  assemblyFile: 'HidGlobal.OK.Readers.dll',
  typeName: 'HidGlobal.OK.Readers.MifareLoadKey'
});
var appReadData = edge.func({
  assemblyFile: 'HidGlobal.OK.Readers.dll',
  typeName: 'HidGlobal.OK.Readers.MifareReadBlockData'
});
var appInitReader = edge.func({
  assemblyFile: 'HidGlobal.OK.Readers.dll',
  typeName: 'HidGlobal.OK.Readers.MifareInitReader'
});
var appWriteData = edge.func({
  assemblyFile: 'HidGlobal.OK.Readers.dll',
  typeName: 'HidGlobal.OK.Readers.MifareWriteBlockData'
});


// An old way to call Edge
/*
var getLoadKey = edge.func({
  source: path.join(__dirname, 'MifareLoadKey.cs')
  ,
  typeName: 'HidGlobal.OK.Readers.MifareLoadKey',
  references :[
    ('HidGlobal.OK.Readers.dll')
  ]});


*/

// Key Loader button
document.getElementById("Load-Key").onclick = loadKey;
//connect to reader button
document.getElementById("ConnectReader").onclick = readerConnect;

// Variables to store user data
var UID;
var WorR;
var sector;
var key;
var Back_key;
var Back_data;
var data0;
var data1;
var data2;
var data3;
const assert = require('assert');
var readerName;

// Exit the application
function ExitClick(){
  self.close()
}

// Load Key Function
function loadKey(){

  prekey = document.getElementById("key").value;
  key = keyCheck(prekey);
appLoadKey(key, function(error, result){
  if(error){
    console.log(error);
    return;
  }
  Back_key = result;
})
//An old way to call function with old implimentation
/*
  getLoadKey(key, (err, result) =>{
    if(err) {
      console.log("ERROR FOUND: ");
      console.log(err);
      return;
    }
    updateLog(result);
    Back_key = result;
  });
  appReader(key, )
*/
  var log;
  if(key != false){
    log = "Key Loaded ";
  }
  else {
    log = "Key not loaded ";
  }
if(Back_key == true){
  updateLog(log + key + " Sucessfully");
}
  else {
    updateLog(log + "Failed");
  }
}


//Connect to Reader Function
function readerConnect() {
  appInitReader(null, function(error, result){
    if(error){
      console.log(error);
      return;
    }
    updateLog(result);
  })
  }

// Write functions
function writeBlock0(){
  getData();
  WorR = "W";
  var log;
  var Block = getBlocknum(0);
  var data = strToHex(data0);
  var payload = {
    _input: data,
    _blockinput: Block
  };
appWriteData(payload, function(error, result){
    if(error){
      console.log(error);
      return;
    }
      if(result == 9000){
      updateLog("Succesful Write");
  }
    else{
      updateLog("Unsuccesful Write");
    }
    })


  // if data = false str to hex failed the 12 char requirement
  if (data != false && key != false){
    //WriteData(data,Block);
    log = "Wrote to Block " + Block + " / (Sector " + sector + " Block 0) " + " Data : " + data + " Key : " + key;
  }
  else{
    if (data == false && key == false){
      log = "Write Failed. Your data and key fields have errors. Check them and try again.";
    }
    else{
      if (data == false){
        log = "Write Failed. Your data has errors. It doesn't translate to 32 Characters long in hex.";
      }
      if (key == false){
        log = "Write Failed. Your key has errors. It doesn't translate to 12 Characters long in hex.";
      }
    }
  }
  updateLog(log);
}

function writeBlock1(){
  getData();
  WorR = "W";
  var log;
  var Block = getBlocknum(1);
  var data = strToHex(data1);
  var appBlock = BackEndstrToHex(Block);
  var payload = {
    _input: data,
    _blockinput: Block
  };
appWriteData(payload, function(error, result){
    if(error){
      console.log(error);
      return;
    }
      if(result == 9000){
      updateLog("Succesful Write");
  }
    else{
      updateLog("Unsuccesful Write");
    }
    })
  // if data = false str to hex failed the 12 char requirement
  if (data1 != false && key != false){

    log = "Wrote to Block " + Block + " / (Sector " + sector + " Block 1) " + " Data :  " + data + " Key : " + key;
  }
  else{
    if (data == false && key == false){
      log = "Write Failed. Your data and key fields have errors. Check them and try again.";
    }
    else{
      if (data == false){
        log = "Write Failed. Your data has errors. It doesn't translate to 32 Characters long in hex.";
      }
      if (key == false){
        log = "Write Failed. Your key has errors. It doesn't translate to 12 Characters long in hex.";
      }
    }
  }
  updateLog(log);
}


function writeBlock2(){
  getData();
  WorR = "W";
  var log;
  var Block = getBlocknum(2);
  var data = strToHex(data2);
  var appBlock = BackEndstrToHex(Block);
  var payload = {
    _input: data,
    _blockinput: Block
  };
appWriteData(payload, function(error, result){
    if(error){
      console.log(error);
      return;
    }
      if(result == 9000){
      updateLog("Succesful Write");
  }
    else{
      updateLog("Unsuccesful Write");
    }
    })
  // if data = false str to hex failed the 12 char requirement
  if (data2 != false && key != false){
    //WriteData(data,Block);
    log = "Wrote to Block " + Block + " / (Sector " + sector + " Block 2) " + " Data :  " + data2 + " Key : " + key;
  }
  else{
    if (data2 == false && key == false){
      log = "Write Failed. Your data and key fields have errors. Check them and try again.";
    }
    else{
      if (data2 == false){
        log = "Write Failed. Your data has errors. It doesn't translate to 32 Characters long in hex.";
      }
      if (key == false){
        log = "Write Failed. Your key has errors. It doesn't translate to 12 Characters long in hex.";
      }
    }
  }
  updateLog(log);
}

function writeBlock3(){
  getData();
  WorR = "W";
  var log;
  var Block = getBlocknum(3);
  var data = strToHex(data3);
  var appBlock = BackEndstrToHex(Block);
  var payload = {
    _input: data,
    _blockinput: Block
  };
appWriteData(payload, function(error, result){
    if(error){
      console.log(error);
      return;
    }
      if(result == 9000){
      updateLog("Succesful Write");
  }
    else{
      updateLog("Unsuccesful Write");
    }
    })
  // if data = false str to hex failed the 12 char requirement
  if (data != false && key != false){
    //WriteData(data,Block);
    log = "Wrote to Block " + Block + " / (Sector " + sector + " Block 3) " + " Data :  " + data + " Key : " + key;
  }
  else{
    if (data == false && key == false){
      log = "Write Failed. Your data and key fields have errors. Check them and try again.";
    }
    else{
      if (data == false){
        log = "Write Failed. Your data has errors. It doesn't translate to 32 Characters long in hex.";
      }
      if (key == false){
        log = "Write Failed. Your key has errors. It doesn't translate to 12 Characters long in hex.";
      }
    }
  }
  updateLog(log);

}

// Read functions
function readBlock0(){
  getData();
  WorR = "R";
  var log;
  var Block = getBlocknum(0);
  appReadData(Block, function(error, result){
    if(error){
      console.log(error);
      return;
    }
    Back_data = result;
  })


  if (key != false){
    //ReadData(Block);
    log = "Read from Block " + Block + " / (Sector " + sector + " Block 0) Key : " + key ;
  }

  else{
    log = "Read failed. Your key has errors. It doesn't translate to 12 Characters long in hex.";
  }
  updateLog("Data: " + Back_data);
  updateLog(log);
}

function readBlock1(){
  getData();
  WorR = "R";
  var log;
  var Block = getBlocknum(1);

  appReadData(Block, function(error, result){
    if(error){
      console.log(error);
      return;
    }
    Back_data = result;
  })

  if (key != false){
    //ReadData(Block);
    log = "Read from Block " + Block + " / (Sector " + sector + " Block 1) Key : " + key ;
  }

  else{
    log = "Read failed. Your key has errors. It doesn't translate to 12 Characters long in hex.";
  }
  updateLog("Data: " + Back_data);
  updateLog(log);
}

function readBlock2(){
  getData();
  WorR = "R";
  var log;
  var Block = getBlocknum(2);

  appReadData(Block, function(error, result){
    if(error){
      console.log(error);
      return;
    }
    Back_data = result;
  })

  if (key != false){
    //ReadData(Block);
    log = "Read from Block " + Block + " / (Sector " + sector + " Block 2) Key : " + key ;
  }

  else{
    log = "Read failed. Your key has errors. It doesn't translate to 12 Characters long in hex.";
  }
  updateLog("Data: " + Back_data);
  updateLog(log);
}

function readBlock3(){
  getData();
  WorR = "R";
  var log;
  var Block = getBlocknum(3);

  appReadData(Block, function(error, result){
    if(error){
      console.log(error);
      return;
    }
    Back_data = result;
  })

  if (key != false){
    //ReadData(Block);
    log = "Read from Block " + Block + " / (Sector " + sector + " Block 3) Key : " + key ;
  }

  else{
    log = "Read failed. Your key has errors. It doesn't translate to 12 Characters long in hex.";
  }
  updateLog("Data: " + Back_data);
  updateLog(log);
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

// Get the data from the user input
function getData(){
  sector = document.getElementById("sector_num").innerHTML;
  prekey = document.getElementById("key").value;
  key = keyCheck(prekey);
  data0 = document.getElementById("usr_block_0").value;
  data1 = document.getElementById("usr_block_1").value;
  data2 = document.getElementById("usr_block_2").value;
  data3 = document.getElementById("usr_block_3").value;
}

// convert string to hex --- turn str into base 10 number then convert that to a base 16 number.
function strToHex(str){
  var int = parseInt(str,10);
  var hex = int.toString(16);
  // if the length of the hex string is 32 it passes other wise it is invalid
  if(hex.length == 32)
      return hex;
  else{
      return false;
  }
}
function BackEndstrToHex(str){
  var hex = str.toString(16);
  if(hex.length == 1){
    hex = "0x0" + hex;
  }
  else {
    return "0x" + hex;
  }
  return hex;
}

// Key has to be 12 chars not converted to hex
// same function as above but checking for length 12
function keyCheck(str){
  if(str.length == 12)
      return str;
  else{
      return false;
  }
}

// Shifts all logs down one and write the new log at the top. Only saves 10 entries.
function updateLog(str){
  document.getElementById("Log10").innerText = document.getElementById("Log9").innerText;
  document.getElementById("Log9").innerText = document.getElementById("Log8").innerText;
  document.getElementById("Log8").innerText = document.getElementById("Log7").innerText;
  document.getElementById("Log7").innerText = document.getElementById("Log6").innerText;
  document.getElementById("Log6").innerText = document.getElementById("Log5").innerText;
  document.getElementById("Log5").innerText = document.getElementById("Log4").innerText;
  document.getElementById("Log4").innerText = document.getElementById("Log3").innerText;
  document.getElementById("Log3").innerText = document.getElementById("Log2").innerText;
  document.getElementById("Log2").innerText = document.getElementById("Log1").innerText;
  document.getElementById("Log1").innerText = str;
}

function clearLog(str){
  document.getElementById("Log10").innerText = ".";
  document.getElementById("Log9").innerText = ".";
  document.getElementById("Log8").innerText = ".";
  document.getElementById("Log7").innerText = ".";
  document.getElementById("Log6").innerText = ".";
  document.getElementById("Log5").innerText = ".";
  document.getElementById("Log4").innerText = ".";
  document.getElementById("Log3").innerText = ".";
  document.getElementById("Log2").innerText = ".";
  document.getElementById("Log1").innerText = ".";
}

// C# server communication write data
function WriteData(data, block) {

  PageMethods.WriteData(UID , key, block, data, onSuccess, onError);

  function onSuccess(result) {
          alert(result);
  }

  function onError(result) {
          alert('Cannot process your request at the moment.');
  }

}
