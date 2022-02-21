
function CreateDateTextBox(input, event) {

    var keyCode = event.which ? event.which : event.keyCode;
    //alert(keyCode);

    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) {
        return true;
    }
    if (parseInt(keyCode) == 8 || parseInt(keyCode) == 46 || parseInt(keyCode) == 47 || parseInt(keyCode) == 9) {

        return true;

    }
    return false;

}


function CreateYearTextBox(input, event) {
    var keyCode = event.which ? event.which : event.keyCode;
    //alert(keyCode);
    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) {
        return true;
    } return false;
}

//New Code
//for Numbers And special character
function CreateSpecialNumericTextBox(input, event) {
    var keyCode = event.which ? event.which : event.keyCode;
    //alert(keyCode);
    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) {
        return true;
    }
    if (parseInt(keyCode) == 46 || parseInt(keyCode) == 47) {

        return true;

    }
    return false;
}

//Ends
function CreateNumericTextControl(input, event, AllowDot) {

    var keyCode = event.which ? event.which : event.keyCode;

    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) {
        return true;
    }
    if (parseInt(keyCode) == 8 || parseInt(keyCode) == 9) { return true; }

    return false;
}

function CreateAlphaNumericTextControl(input, event) {

    var keyCode = event.which ? event.which : event.keyCode;
    //alert(keyCode);
    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) { return true; }

    //Small Alphabets
    if (parseInt(keyCode) >= 97 && parseInt(keyCode) <= 122) {
        return true;
    }
    //Caps Alphabets
    if (parseInt(keyCode) >= 65 && parseInt(keyCode) <= 90) {
        return true;
    }

    if (parseInt(keyCode) == 8 || parseInt(keyCode) == 9) { return true; }
    input.focus();
    return false;
}

function CreateNumericTextBox(input, event, AllowDot) {

    var keyCode = event.which ? event.which : event.keyCode;


    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) {
        return true;
    }
    if (parseInt(keyCode) == 8 || parseInt(keyCode) == 46 || parseInt(keyCode) == 9) { return true; }

    if (AllowDot) {

        if (parseInt(keyCode) == 32) { return true; }
    }

    return false;

}
//for age                                           
function CreateNumericAge(input, event, AllowDot) {

    var keyCode = event.which ? event.which : event.keyCode;
    //alert(keyCode);

    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) {
        return true;
    }
    if (parseInt(keyCode) == 8 || parseInt(keyCode) == 9) { return true; }

    if (AllowDot) {

        if (parseInt(keyCode) == 32) { return true; }
    }

    return false;

}
//End                                                             



function CreateAlphaNumericTextBox(input, event) {

    var keyCode = event.which ? event.which : event.keyCode;
    //alert(keyCode);
    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) { return true; }

    //Small Alphabets
    if (parseInt(keyCode) >= 97 && parseInt(keyCode) <= 122 ) {
        return true;
    }
    //Caps Alphabets
    if (parseInt(keyCode) >= 65 && parseInt(keyCode) <= 90 ) {
        return true;
    }
   

    if (parseInt(keyCode) == 8 || parseInt(keyCode) == 46 || parseInt(keyCode) == 9  ) { return true; }
    input.focus();
    return false;


}


function CreateStringTextBox(input, event) {
    var keyCode = event.which ? event.which : event.keyCode;
    // alert(keyCode);


    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) { return false; }

    //Small Alphabets
    if (parseInt(keyCode) >= 97 && parseInt(keyCode) <= 122) {
        return true;
    }
    //Caps Alphabets
    if (parseInt(keyCode) >= 65 && parseInt(keyCode) <= 90) {
        return true;
    }
    //Space-Return-Dot
    if (parseInt(keyCode) == 32 || parseInt(keyCode) == 13 || parseInt(keyCode) == 40 || parseInt(keyCode) == 41 || parseInt(keyCode) == 46 || parseInt(keyCode) == 8 || parseInt(keyCode) == 9) {

        return true;
    }

    input.focus();
    return false;

    //alert(keyCode);
}

function CreateStringTextBoxForOthers(input, event) {
    var keyCode = event.which ? event.which : event.keyCode;
    // alert(keyCode);


    if (parseInt(keyCode) >= 48 && parseInt(keyCode) <= 57) { return true; }

    //Small Alphabets
    if (parseInt(keyCode) >= 97 && parseInt(keyCode) <= 122) {
        return true;
    }
    //Caps Alphabets
    if (parseInt(keyCode) >= 65 && parseInt(keyCode) <= 90) {
        return true;
    }
    //Space-Return-Dot
    if (parseInt(keyCode) == 32 || parseInt(keyCode) == 13 || parseInt(keyCode) == 40 || parseInt(keyCode) == 41 || parseInt(keyCode) == 46 || parseInt(keyCode) == 8 || parseInt(keyCode) == 9 || parseInt(keyCode) == 44 || parseInt(keyCode) == 58) {

        return true;
    }

    input.focus();
    return false;

    //alert(keyCode);
}

function CreateCAPSStringTextBox(input, event) {

    return CreateStringTextBox(input, event);

    //Note: not working in Mozilla  prob may be  onfocusout  Event not supported with Mozilla.
    //Write this inside input tag  
    // onfocusout="if(this.value!=null){this.value=this.value.toUpperCase();}"
    //The following code is solving the problem..
    //onBlur="if(this.value!=null){this.value=this.value.toUpperCase();}"
}



function _ValidFile(File, isOptional, Message) {

    var FileFormats = new Array(".jpg", ".png");
    return ValidateFile_Formats(File, isOptional, FileFormats, Message)
}
function _validFile(File, isOptional, Message) {

    var FileFormats = new Array(".jpg", ".png");
    return ValidateFile_Formats(File, isOptional, FileFormats, Message)
}

function ValidateFile_Formats(File, isOptional, AllowedFormats, Message) {

    if (File == null) { return true; }
    // alert( File.value);
    if ((File.value.length != 0)) {
        var fileName = File.value;
        var Ext = fileName.substr(fileName.lastIndexOf("."), fileName.length - fileName.lastIndexOf(".")).toLowerCase();
        if (Ext == null) { return true; }
        //alert(Ext);
        var validFormat = false;
        var tempI = 0;
        for (tempI = 0; tempI < AllowedFormats.length; tempI++) {
            if (AllowedFormats[tempI].toLowerCase() == Ext) { validFormat = true; }
        }

        if (!validFormat) {
            alert("Please Select Valid File.");
            File.focus();
            return false;

        }

    }

    else {
        if (!isOptional) {
            alert("Kindly enclose " + Message);
            File.focus();
            return false;
        }
    }

    return true;

}


function RadioCheckedValue(theField) {


    for (i = 0; i < theField.length; i++) {
        if (theField[i].checked) { return theField[i].value; }
    }
    return null;
}


//Todo Switch Case May be Added. In  a New Function.
//So that  every time no need to write the Regular Expression.
//Dileep.M 20 Aug 2007.

function ValidateInput(Input, Exp, Msg, isMandatory) {
    //This Function added on 20 Aug 2007 by Dileep.M

    // Some Validation Expressions.
    //(Growing  List)

    //       Name=^[a-zA-Z]+$";// Name Mandatory .
    //       NMName=^[a-zA-Z]*$";// Name Non Mandatory .
    //	     SDName= "^[a-zA-Z\\s.]+$";//Allows Mandatory  Name With Space and Dot
    //	     SName= "^[a-zA-Z\\s]+$";//Allows Mandatory  Name With Space 

    //       HName="^[a-zA-Z\\u0902-\\u0964]+$";//Hindi Name Mandatory .
    //	     NMHName="^[a-zA-Z\\u0902-\\u0964]*$";//Hindi Name Non Mandatory.
    //	     SDHName= "^[a-zA-Z\\s.\\u0902-\\u0964]+$";//Allows Mandatory Hindi Name With Space and Dot
    //	     SHName= "^[a-zA-Z\\s\\u0902-\\u0964]+$";//Allows Mandatory Hindi Name With Space 
    //	    
    //	     Email="\\S+@\\S+\\.\\S+";
    //	     Mobile="^[0-9]{10}$";
    //	     PANNo="^[a-zA-Z]{1}[a-zA-Z0-9]+[0-9]+[a-zA-Z0-9]+$";
    //       Explanation--->Starts with alphabet then may be combination of alphanumeric and it must contain a numeric and alphanumeric
    //	     PANNoLength="^[a-zA-Z0-9]{10}$";
    //
    //       PincOde="^[0-9]{6}$"
    //       Std="^[0-9]{3}[0-9]*$"      
    //       Phone= "^[0-9]{6}[0-9]*$"      

    if (Input == null) { return true; }

    var proceed = false;
    var CreateId = Input.id + "_" + "ValidText";

    if (isMandatory) {
        if (Input.value == "") {


            var Elem = CreateSpan("notetext", "Please enter " + Msg);
            AppendChild(Input, Elem, CreateId);
            //MsgBox("Please enter "+Msg,Input);
            alert("Please enter " + Msg);
            Input.focus();
            return false;
        }
        else { proceed = true; }


    }
    else {
        if (Input.value != "") { proceed = true; }

    }

    if (proceed) {

        var x = validRExpression(Input.value, Exp);
        if (x) {
            //Claer Prev Messages
            var Elem = CreateSpan("notetext", "");
            AppendChild(Input, Elem, CreateId);
            return true;
        }
        else {
            //Todo..Dileep.M  20 Aug 2007
            //Here  Input Style  may be chaged(to highlight the Control). 
            //Message can be appended as a  child to the Control.

            var Elem = CreateSpan("notetext", "Please enter valid " + Msg);
            AppendChild(Input, Elem, CreateId);
            //MsgBox("Please enter "+Msg,Input);
            alert("Please enter valid " + Msg);
            Input.focus();
            return false;
        }
    }
    else {
        //ClearPrevMess if any  
        var Elem = CreateSpan("notetext", "");
        AppendChild(Input, Elem, CreateId);

        //CreateElement(Input,Elem,CreateId);   


        return true;
    }


}

function ValidateInput_Modifier(Input, Exp, Msg, isMandatory, Modifiers) {
    //This Function added on 13 Feb 2008 by Dileep.M


    // Some Validation Expressions.
    //(Growing  List)

    //       Name=^[a-zA-Z]+$";// Name Mandatory .
    //       NMName=^[a-zA-Z]*$";// Name Non Mandatory .
    //	     SDName= "^[a-zA-Z\\s.]+$";//Allows Mandatory  Name With Space and Dot
    //	     SName= "^[a-zA-Z\\s]+$";//Allows Mandatory  Name With Space 

    //       HName="^[a-zA-Z\\u0902-\\u0964]+$";//Hindi Name Mandatory .
    //	     NMHName="^[a-zA-Z\\u0902-\\u0964]*$";//Hindi Name Non Mandatory.
    //	     SDHName= "^[a-zA-Z\\s.\\u0902-\\u0964]+$";//Allows Mandatory Hindi Name With Space and Dot
    //	     SHName= "^[a-zA-Z\\s\\u0902-\\u0964]+$";//Allows Mandatory Hindi Name With Space 
    //	    
    //	     Email="\\S+@\\S+\\.\\S+";
    //	     Mobile="^[0-9]{10}$";
    //	     PANNo="^[a-zA-Z]{1}[a-zA-Z0-9]+[0-9]+[a-zA-Z0-9]+$";
    //       Explanation--->Starts with alphabet then may be combination of alphanumeric and it must contain a numeric and alphanumeric
    //	     PANNoLength="^[a-zA-Z0-9]{10}$";
    //
    //       PincOde="^[0-9]{6}$"
    //       Std="^[0-9]{3}[0-9]*$"      
    //       Phone= "^[0-9]{6}[0-9]*$"      

    if (Input == null) { return true; }

    var proceed = false;
    var CreateId = Input.id + "_" + "ValidText";

    if (isMandatory) {
        if (Input.value == "") {

            //alert("Please enter "+Msg); 
            var Elem = CreateSpan("notetext", "Please enter " + Msg);
            AppendChild(Input, Elem, CreateId);
            MsgBox("Please enter " + Msg, Input);
            //Input.focus();
            return false;
        }
        else { proceed = true; }


    }
    else {
        if (Input.value != "") { proceed = true; }

    }

    if (proceed) {

        var x = validRExpression_Modifier(Input.value, Exp, Modifiers);
        if (x) {
            //Claer Prev Messages
            var Elem = CreateSpan("notetext", "");
            AppendChild(Input, Elem, CreateId);
            return true;
        }
        else {
            //Todo..Dileep.M  20 Aug 2007
            //Here  Input Style  may be chaged(to highlight the Control). 
            //Message can be appended as a  child to the Control.

            var Elem = CreateSpan("notetext", "Please enter valid " + Msg);
            AppendChild(Input, Elem, CreateId);
            MsgBox("Please enter " + Msg, Input);
            // alert("Please enter valid "+Msg);
            //Input.focus();
            return false;
        }
    }
    else {
        //ClearPrevMess if any  
        var Elem = CreateSpan("notetext", "");
        AppendChild(Input, Elem, CreateId);

        //CreateElement(Input,Elem,CreateId);   


        return true;
    }


}


function CreateSpan(CSSClass, textVal) {
    var Elem = document.createElement("span");
    Elem.className = CSSClass;
    Elem.appendChild(document.createElement("br"));
    Elem.appendChild(document.createTextNode(textVal));
    return Elem;
}
function AppendChild(Input, Elem, Id) {

    var CElem = document.getElementById(Id);
    if (CElem == null) {
        //Assaign Id..        
        //and Create it.
        Elem.setAttribute("id", Id);
        AppendControl(Input, Elem);

    }
    else {
        //Already Exists
        //So Change Message
        //alert(Elem.innerHTML);
        CElem.innerHTML = Elem.innerHTML;

    }


}
function AppendControl(Input, Elem) {
    //alert("Tag: "+Input.parentNode);
    Input.parentNode.appendChild(Elem);
    //alert("Id: "+Elem.id);
}


function validRExpression(Value, Exp) {
    //This Function added on 20 Aug 2007 by Dileep.M

    //Declare regular expression
    var RegEx = new RegExp(Exp);
    //Match Value to Regular Expression
    //Match method returns a boolean value
    if (Value.match(RegEx)) {
        return true;
    }
    else {

        return false;
    }

}

function validRExpression_Modifier(Value, Exp, Modifiers) {
    //This Function added on 13 Feb 2008 by Dileep.M

    //Declare regular expression    with Modifiers
    var RegEx = new RegExp(Exp, Modifiers);
    //Match Value to Regular Expression
    //Match method returns a boolean value
    if (Value.match(RegEx)) {
        return true;
    }
    else {

        return false;
    }

}


function ValidateChkLst(fieldId, Msg) {

    var options = document.getElementById(fieldId).getElementsByTagName('input');
    var ischecked = false;
    args.IsValid = false;
    for (i = 0; i < options.length; i++) {
        var opt = options[i];
        if (opt.type == "checkbox") {
            if (opt.checked) {
                ischecked = true;
                //args.IsValid = true;
                alert(Msg);
            }
        }
    }
}



function ValidateRadio(theField, fieldName) {
    if (theField == null) { return true; }




    var flag = false;

    for (i = 0; i < theField.length; i++) {
        if (!theField[i].disabled) {
            if (theField[i].checked) {

                flag = true;
            }
        }

        else { flag = true; }

    }
    if (!flag) {
        alert("Please select one of the " + fieldName + " options.");

        return false;
    }




    return true;

}



function IsRadioChecked(theField) {
    if (theField == null) { return true; }

    var flag = false;

    for (i = 0; i < theField.length; i++) {
        if (!theField[i].disabled) {
            if (theField[i].checked) {

                flag = true;
            }
        }

        else { flag = true; }

    }
    if (!flag) {
        //  alert("Please select one of the "+fieldName +" options.");
        return false;
    }


    return true;

}


function ValidateInputRadio(rd, Msg) {
    var Elems = rd;

    var selected = false;


    for (var i = 0; i < Elems.length; i++) {

        if (!Elems[i].disabled) {
            if (Elems[i].checked) { selected = true; }
        }
    }

    if (!selected) { alert("Please select on of the " + Msg + "."); }

    return selected;

}

function _ValidateDropdown(theField, fieldName) {
    if (theField.selectedIndex == 0) {
        alert("Please Select " + fieldName);
        return false;
    }
    return true;
}


function MsgBox(Message, Input) {


    try {
        if (useAlert != null) { alert(Message); Input.focus(); return; }
        if (Content != "") {
            var w = screen.availWidth;
            var h = screen.availHeight;
            var OK = "<a href='javascript:void(0);' onclick='javascript:try{GEId(\"FloatCanvas\").style.display=\"none\";GEId(\"divMsgBox\").style.display=\"none\";GEId(\"" + Input.id + "\").focus();}catch(err){};'> OK </a>";
            //var Elem=(GEId(\"lblMsg\")!=null)?GEId(\"lblMsg\"):GEId(\"Msg\");if(Elem)Elem.style.display=\"block\";
            var Content = "";
            var ContentElem = document.getElementById('divMsgBox');


            if (ContentElem == null) {
                Content = "<div id='divMsgBox' style='top:" + ((h) / 2.5) + "px;left:" + ((w - 350) / 2) + "px;position:absolute;width:350px;z-index:10001'>" +
	                                               "<table  style='width:90%;background-color:white; border:solid 2px #000;'>" +
	                                                    "<tr><td style='color:white; background-color:white;text-align:center; font-size:14px;'>" +
	                                                    "<b>" + "Message" + "</b>" +
	                                                    "</td></tr>" +
	                                                    "<tr><td style='color:red; text-align:center;'>" +
	                                                        "<b>" +
    	                                                          Message +
                                                             "</b>" +
	                                                    "</td></tr>" +
	                                                    "<tr><td align='center'>" +
                                                                OK
                "</td></tr>" +

             "</table>" +
         "</div>";
            }

            else {

                ContentElem.innerHTML = "<table  style='width:90%;background-color:white; border:solid 2px #000;'>" +
                                                    "<tr><td style='color:black; text-align:center; font-size:14px;'>" +
                                                    "<b>" + "Message" + "</b>" +
                                                    "</td></tr>" +
                                                    "<tr><td style='color:red; text-align:center;'>" +
                                                        "<b>" +
                                                          Message +
                                                         "</b>" +
                                                    "</td></tr>" +
                                                    "<tr><td align='center'>" +
                                                            OK
                "</td></tr>" +

             "</table>";
                ContentElem.style.display = "block";//alert(ContentElem.outerHTML);

            }


            var Can = document.getElementById('FloatCanvas');
            if (Can == null) {

                Content = "<div id='FloatCanvas'  style='z-index:500;background-color:#ccc;position:absolute;top:0px;left:0px;width:" + w + "px;height:" + h + "px;opacity: 0.3;filter:alpha(opacity=30);'></div>" + Content;
            }
            else {

                Can.style.display = "block";
            }


            var Elem = document.createElement("div");
            Elem.innerHTML = Content;
            //document.body.appendChild(Elem) ;                    
            Input.parentNode.appendChild(Elem);
            //Elem.focus();
            Input.focus();

        }

    } catch (err) { }


}

function GEId(X) { return document.getElementById(X); }