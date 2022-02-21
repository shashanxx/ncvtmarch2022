<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrVerificationNew.aspx.cs" Inherits="Principle_PrVerificationNew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Verification</title>
    <style>
        .ddlstyle {
            height: 25px;
        }
    </style>
    <script type="text/javascript">
        function FiltervalidationCheck() {
            if (document.getElementById("ddlAdmissionYear").value == "0") {
                alert("Please select admission year");
                document.getElementById("ddlAdmissionYear").focus();
                return false;
            }
            else if (document.getElementById("ddlTradeName").value == "0") {
                alert("Please select trade name");
                document.getElementById("ddlTradeName").focus();
                return false;
            }
            else if (document.getElementById("ddlSemester").value == "0") {
                alert("Please select Semester");
                document.getElementById("ddlSemester").focus();
                return false;
            }
            else if (document.getElementById("ddlexamtype").value == "0") {
                alert("Please select exam type");
                document.getElementById("ddlexamtype").focus();
                return false;
            }
            else
                return true;
        }

        function GridvalidationCheck() {
            //debugger;
            var gvDrv = document.getElementById("<%=GridView1.ClientID %>");
            var check = true;
            for (i = 0; i < gvDrv.rows.length - 1; i++) {
                if (document.getElementById('GridView1_ddlCanEligibility_' + i).value == "0") {
                    alert("Please select candidates eligibility");
                    document.getElementById('GridView1_ddlCanEligibility_' + i).focus();
                    check = false;
                    break;
                }
                else if (document.getElementById('GridView1_ddlCanEligibility_' + i).value == "for verification" && document.getElementById('GridView1_ddlCanEligibility_' + i).style.display != 'none') {
                    if (document.getElementById('GridView1_ddlAttendance_' + i).value == "0") {
                        alert("Please select attendance");
                        document.getElementById('GridView1_ddlAttendance_' + i).focus();
                        check = false;
                        break;
                    }
                    if (document.getElementById('GridView1_ddlSessMarks_' + i).value == "0") {
                        alert("Please select sessional marks");
                        document.getElementById('GridView1_ddlSessMarks_' + i).focus();
                        check = false;
                        break;
                    }

                    var chkPaper1 = document.getElementById('GridView1_chkPaper1_' + i);
                    var chkPaper2 = document.getElementById('GridView1_chkPaper2_' + i);
                    var chkPaper3 = document.getElementById('GridView1_chkPaper3_' + i);
                    var chkPractical = document.getElementById('GridView1_chkPractical_' + i);
                    var hdnexamtype = document.getElementById('hdnexamtype');
                    var CanResultStatusED = document.getElementById('GridView1_ddlCanResultStatusED_' + i);
                    var CanResultStatusPractical = document.getElementById('GridView1_ddlCanResultStatusPractical_' + i);

                    var hdnPaper1Status = document.getElementById('GridView1_hdnPaper1Status_' + i);
                    var hdnPaper2Status = document.getElementById('GridView1_hdnPaper2Status_' + i);
                    var hdnPaper3Status = document.getElementById('GridView1_hdnPaper3Status_' + i);
                    var hdnPracticalStatus = document.getElementById('GridView1_hdnPracticalStatus_' + i);

                    if (hdnexamtype.value.toLowerCase() == "ex") {
                        var Excheck = true;
                        if (hdnPaper1Status.value.toLowerCase() == "yes") {
                            if (chkPaper1.checked)
                                Excheck = false;
                        }
                        if (hdnPaper2Status.value.toLowerCase() == "yes") {
                            if (chkPaper2.checked)
                                Excheck = false;
                        }
                        if (hdnPaper3Status.value.toLowerCase() == "yes") {
                            if (chkPaper3.checked)
                                Excheck = false;
                        }
                        if (hdnPracticalStatus.value.toLowerCase() == "yes") {
                            if (chkPractical.checked)
                                Excheck = false;
                        }
                        if (Excheck) {
                            alert("Please check atleast one paper");
                            check = false;
                            break;
                        }
                    }
                    else {
                        if (hdnPaper1Status.value.toLowerCase() == "yes") {
                            if (!chkPaper1.checked) {
                                //alert("Please check Paper1 checkbox");
                                //chkPaper1.focus();
                                //check = false;
                                //break;
                            }
                        }
                        if (hdnPaper2Status.value.toLowerCase() == "yes") {
                            //if (!chkPaper2.checked) {
                            //    alert("Please check Paper2 checkbox");
                            //    chkPaper2.focus();
                            //    check = false;
                            //    break;
                            //}
                        }
                        if (hdnPaper3Status.value.toLowerCase() == "yes") {
                            if (!chkPaper3.checked) {
                                if (CanResultStatusED.value == "Already PASS") {

                                } else {
                                    alert("Please check Paper3 checkbox");
                                    chkPaper3.focus();
                                    check = false;
                                    break;
                                }
                            }
                        }
                        if (hdnPracticalStatus.value.toLowerCase() == "yes") {
                            if (!chkPractical.checked) {
                                if (CanResultStatusPractical.value == "Already PASS") {

                                } else {
                                    alert("Please check Practical checkbox");
                                    chkPractical.focus();
                                    check = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return check;
        }

        function PaperAmountCalc(thie) {
            //debugger;
            var row = thie.parentNode.parentNode;
            var i = row.rowIndex - 1;
            var Paper1fee = document.getElementById('GridView1_hdnPaper1fee_' + i);
            var chkPaper1 = document.getElementById('GridView1_chkPaper1_' + i);
            var Paper2fee = document.getElementById('GridView1_hdnPaper2fee_' + i);
            var chkPaper2 = document.getElementById('GridView1_chkPaper2_' + i);
            var Paper3fee = document.getElementById('GridView1_hdnPaper3fee_' + i);
            var chkPaper3 = document.getElementById('GridView1_chkPaper3_' + i);
            var PracticalFees = document.getElementById('GridView1_hdnPracticalFees_' + i);
            var chkPractical = document.getElementById('GridView1_chkPractical_' + i);
            var txtAmount = document.getElementById('GridView1_txtAmount_' + i);

            var hdnPaper1Status = document.getElementById('GridView1_hdnPaper1Status_' + i);
            var hdnPaper2Status = document.getElementById('GridView1_hdnPaper2Status_' + i);
            var hdnPaper3Status = document.getElementById('GridView1_hdnPaper3Status_' + i);
            var hdnPracticalStatus = document.getElementById('GridView1_hdnPracticalStatus_' + i);

            var totalamount = 0;
            if (hdnPaper1Status.value.toLowerCase() == "yes") {
                if (chkPaper1.checked && Paper1fee.value != "")
                    totalamount += parseInt(Paper1fee.value);
            }
            if (hdnPaper2Status.value.toLowerCase() == "yes") {
                if (chkPaper2.checked && Paper2fee.value != "")
                    totalamount += parseInt(Paper2fee.value);
            }
            if (hdnPaper3Status.value.toLowerCase() == "yes" || hdnPracticalStatus.value.toLowerCase() == "yes") {
                if (hdnPaper3Status.value.toLowerCase() == "yes" && chkPaper3.checked && Paper3fee.value != "")
                    totalamount += parseInt(Paper3fee.value);
                else if (hdnPracticalStatus.value.toLowerCase() == "yes" && chkPractical.checked && PracticalFees.value != "")
                    totalamount += parseInt(PracticalFees.value);
            }
            //if (hdnPaper3Status.value.toLowerCase() == "yes") {
            //    if (chkPaper3.checked && Paper3fee.value != "")
            //        totalamount += parseInt(Paper3fee.value);
            //}
            //if (hdnPracticalStatus.value.toLowerCase() == "yes") {
            //    if (chkPractical.checked && PracticalFees.value != "")
            //        totalamount += parseInt(PracticalFees.value);
            //}
            txtAmount.value = totalamount;
        }

        function CheckCanEligiblity(thie) {
            //debugger;
            var row = thie.parentNode.parentNode;
            var i = row.rowIndex - 1;
            var CanEligibility = document.getElementById('GridView1_ddlCanEligibility_' + i);
            var CanResultStatusED = document.getElementById('GridView1_ddlCanResultStatusED_' + i);
            var CanResultStatusPractical = document.getElementById('GridView1_ddlCanResultStatusPractical_' + i);
            var Attendance = document.getElementById('GridView1_ddlAttendance_' + i);
            var SessMarks = document.getElementById('GridView1_ddlSessMarks_' + i);

            var chkPaper1 = document.getElementById('GridView1_chkPaper1_' + i);
            var chkPaper2 = document.getElementById('GridView1_chkPaper2_' + i);
            var chkPaper3 = document.getElementById('GridView1_chkPaper3_' + i);
            var chkPractical = document.getElementById('GridView1_chkPractical_' + i);
            var txtAmount = document.getElementById('GridView1_txtAmount_' + i);
            var hdnPaper1fee = document.getElementById('GridView1_hdnPaper1fee_' + i);
            var hdnPaper2fee = document.getElementById('GridView1_hdnPaper2fee_' + i);
            var hdnPaper3fee = document.getElementById('GridView1_hdnPaper3fee_' + i);
            var hdnPracticalFees = document.getElementById('GridView1_hdnPracticalFees_' + i);
            var hdnexamtype = document.getElementById('hdnexamtype');
            var lblCLocked = document.getElementById('GridView1_lblCLocked_' + i);

            var hdnPaper1Status = document.getElementById('GridView1_hdnPaper1Status_' + i);
            var hdnPaper2Status = document.getElementById('GridView1_hdnPaper2Status_' + i);
            var hdnPaper3Status = document.getElementById('GridView1_hdnPaper3Status_' + i);
            var hdnPracticalStatus = document.getElementById('GridView1_hdnPracticalStatus_' + i);
            var hdnPaper1chk = document.getElementById('GridView1_hdnPaper1chk_' + i);
            var hdnPaper2chk = document.getElementById('GridView1_hdnPaper2chk_' + i);
            var hdnPaper3chk = document.getElementById('GridView1_hdnPaper3chk_' + i);
            var hdnPracticalchk = document.getElementById('GridView1_hdnPracticalchk_' + i);

            if (CanEligibility.value != "0") {
                if (CanEligibility.value == "discharge" || CanEligibility.value == "for non-verification") {
                    Attendance.value = "0";
                    Attendance.disabled = true;
                    SessMarks.value = "0";
                    SessMarks.disabled = true;
                    if (hdnPaper1Status.value.toLowerCase() == "yes") {
                        chkPaper1.checked = false;
                        chkPaper1.disabled = true;
                    }
                    if (hdnPaper2Status.value.toLowerCase() == "yes") {
                        chkPaper2.checked = false;
                        chkPaper2.disabled = true;
                    }
                    if (hdnPaper3Status.value.toLowerCase() == "yes") {
                        chkPaper3.checked = false;
                        chkPaper3.disabled = true;
                    }
                    if (hdnPracticalStatus.value.toLowerCase() == "yes") {
                        chkPractical.checked = false;
                        chkPractical.disabled = true;
                    }
                    txtAmount.value = "0";
                }
                else {
                    //add new code for Choicelocked No
                    if ((lblCLocked.innerText).toLowerCase() == "yes") {
                        Attendance.disabled = false;
                        SessMarks.disabled = false;

                        Attendance.value = "greater than or equal to 80%";
                        SessMarks.value = "greater than or equal to 60% for practical and greater than or equal to 40% for theory";

                        if (hdnexamtype.value.toLowerCase() == "reg") {
                            if (hdnPaper1Status.value.toLowerCase() == "yes") {
                                if (parseInt(hdnPaper1fee.value) == 0)
                                    chkPaper1.disabled = true;
                                else
                                    chkPaper1.disabled = true;
                            }
                            if (hdnPaper2Status.value.toLowerCase() == "yes") {
                                if (parseInt(hdnPaper2fee.value) == 0)
                                    chkPaper2.disabled = true;
                                else
                                    chkPaper2.disabled = true;
                            }
                            if (hdnPaper3Status.value.toLowerCase() == "yes") {
                                if (parseInt(hdnPaper3fee.value) == 0)
                                    chkPaper3.disabled = true;
                                else
                                    chkPaper3.disabled = false;
                            }
                            if (hdnPracticalStatus.value.toLowerCase() == "yes") {
                                if (parseInt(hdnPracticalFees.value) == 0)
                                    chkPractical.disabled = true;
                                else
                                    chkPractical.disabled = false;
                            }
                        }
                        else {
                            if (hdnPaper1Status.value.toLowerCase() == "yes")
                                chkPaper1.disabled = true;

                            if (hdnPaper2Status.value.toLowerCase() == "yes")
                                chkPaper2.disabled = true;

                            if (hdnPaper3Status.value.toLowerCase() == "yes")
                                chkPaper3.disabled = false;

                            if (hdnPracticalStatus.value.toLowerCase() == "yes")
                                chkPractical.disabled = false;
                        }

                        txtAmount.value = "0";
                        if (hdnPaper1chk != null) {
                            if (hdnPaper1chk.value.toLowerCase() == "0")
                                chkPaper1.disabled = true;
                        }
                        if (hdnPaper2chk != null) {
                            if (hdnPaper2chk.value.toLowerCase() == "0")
                                chkPaper2.disabled = true;
                        }
                        if (hdnPaper3chk != null) {
                            if (hdnPaper3chk.value.toLowerCase() == "0")
                                chkPaper3.disabled = true;
                        }
                        if (hdnPracticalchk != null) {
                            if (hdnPracticalchk.value.toLowerCase() == "0")
                                chkPractical.disabled = true;
                        }
                    }
                    else {
                        Attendance.value = "0";
                        Attendance.disabled = true;
                        SessMarks.value = "0";
                        SessMarks.disabled = true;
                        if (hdnPaper1Status.value.toLowerCase() == "yes") {
                            chkPaper1.checked = false;
                            chkPaper1.disabled = true;
                        }
                        if (hdnPaper2Status.value.toLowerCase() == "yes") {
                            chkPaper2.checked = false;
                            chkPaper2.disabled = true;
                        }
                        if (hdnPaper3Status.value.toLowerCase() == "yes") {
                            chkPaper3.checked = false;
                            chkPaper3.disabled = true;
                        }
                        if (hdnPracticalStatus.value.toLowerCase() == "yes") {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                        txtAmount.value = "0";
                        CanEligibility.value = "0";
                        alert("Student has not locked the exam city choice preference.");
                    }
                }
            }
            else {
                Attendance.value = "0";
                Attendance.disabled = true;
                SessMarks.value = "0";
                SessMarks.disabled = true;
                if (hdnPaper1Status.value.toLowerCase() == "yes") {
                    chkPaper1.checked = false;
                    chkPaper1.disabled = true;
                }
                if (hdnPaper2Status.value.toLowerCase() == "yes") {
                    chkPaper2.checked = false;
                    chkPaper2.disabled = true;
                }
                if (hdnPaper3Status.value.toLowerCase() == "yes") {
                    chkPaper3.checked = false;
                    chkPaper3.disabled = true;
                }
                if (hdnPracticalStatus.value.toLowerCase() == "yes") {
                    chkPractical.checked = false;
                    chkPractical.disabled = true;
                }
                txtAmount.value = "0";
            }

            if (CanEligibility.value == "for verification") {
                if (CanResultStatusED != null) {
                    if (CanResultStatusED.value == "Already PASS") {
                        if (chkPaper3 != null) {
                            chkPaper3.checked = false;
                            chkPaper3.disabled = true;
                        }
                    }
                    else {
                        if (CanResultStatusPractical.value == "Already PASS") {
                            if (chkPractical != null) {
                                chkPractical.checked = false;
                                chkPractical.disabled = true;
                            }
                        }
                    }
                }
                else {
                    if (CanResultStatusPractical.value == "Already PASS") {
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                    }
                }
            }
        }

        function CheckCanResultStatusED(thie) {
            debugger;
            var row = thie.parentNode.parentNode;
            var i = row.rowIndex - 1;
            var CanEligibility = document.getElementById('GridView1_ddlCanEligibility_' + i);
            var CanResultStatusED = document.getElementById('GridView1_ddlCanResultStatusED_' + i);
            var CanResultStatusPractical = document.getElementById('GridView1_ddlCanResultStatusPractical_' + i);
            var Attendance = document.getElementById('GridView1_ddlAttendance_' + i);
            var SessMarks = document.getElementById('GridView1_ddlSessMarks_' + i);

            var chkPaper1 = document.getElementById('GridView1_chkPaper1_' + i);
            var chkPaper2 = document.getElementById('GridView1_chkPaper2_' + i);
            var chkPaper3 = document.getElementById('GridView1_chkPaper3_' + i);
            var chkPractical = document.getElementById('GridView1_chkPractical_' + i);
            var txtAmount = document.getElementById('GridView1_txtAmount_' + i);
            var hdnPaper1fee = document.getElementById('GridView1_hdnPaper1fee_' + i);
            var hdnPaper2fee = document.getElementById('GridView1_hdnPaper2fee_' + i);
            var hdnPaper3fee = document.getElementById('GridView1_hdnPaper3fee_' + i);
            var hdnPracticalFees = document.getElementById('GridView1_hdnPracticalFees_' + i);
            var hdnexamtype = document.getElementById('hdnexamtype');
            var lblCLocked = document.getElementById('GridView1_lblCLocked_' + i);

            var hdnPaper1Status = document.getElementById('GridView1_hdnPaper1Status_' + i);
            var hdnPaper2Status = document.getElementById('GridView1_hdnPaper2Status_' + i);
            var hdnPaper3Status = document.getElementById('GridView1_hdnPaper3Status_' + i);
            var hdnPracticalStatus = document.getElementById('GridView1_hdnPracticalStatus_' + i);
            var hdnPaper1chk = document.getElementById('GridView1_hdnPaper1chk_' + i);
            var hdnPaper2chk = document.getElementById('GridView1_hdnPaper2chk_' + i);
            var hdnPaper3chk = document.getElementById('GridView1_hdnPaper3chk_' + i);
            var hdnPracticalchk = document.getElementById('GridView1_hdnPracticalchk_' + i);

            if (CanEligibility.value != "for verification") {
                if (CanResultStatusED.value == "Already PASS" && CanResultStatusPractical.value == "Already PASS") {
                    CanEligibility.value = "for non-verification";
                    CanEligibility.disabled = true;
                    Attendance.value = "0";
                    Attendance.disabled = true;
                    SessMarks.value = "0";
                    SessMarks.disabled = true;
                    if (chkPaper1 != null) {
                        chkPaper1.checked = false;
                        chkPaper1.disabled = true;
                    }
                    if (chkPaper2 != null) {
                        chkPaper2.checked = false;
                        chkPaper2.disabled = true;
                    }
                    if (chkPaper3 != null) {
                        chkPaper3.checked = false;
                        chkPaper3.disabled = true;
                    }
                    if (chkPractical != null) {
                        chkPractical.checked = false;
                        chkPractical.disabled = true;
                    }
                    txtAmount.value = "0";
                } else if (CanResultStatusED.value == "Already PASS") {
                    CanEligibility.disabled = false;
                    if (chkPaper3 != null) {
                        chkPaper3.checked = false;
                        chkPaper3.disabled = true;
                    }
                } else if (CanResultStatusED.value == "0") {
                    CanEligibility.disabled = false;
                    if (chkPaper3 != null) {
                        chkPaper3.checked = false;
                    }
                    if (CanEligibility.value == "for non-verification") {
                        if (chkPaper3 != null) {
                            chkPaper3.disabled = true;
                        }
                    }
                } else {
                    CanEligibility.value = "for non-verification";
                    CanEligibility.disabled = false;
                    txtAmount.value = "0";
                }
            } else if (CanEligibility.value == "for verification") {
                if (CanResultStatusED.value == "Already PASS" && CanResultStatusPractical.value == "Already PASS") {
                    CanEligibility.value = "for non-verification";
                    CanEligibility.disabled = true;
                    Attendance.value = "0";
                    Attendance.disabled = true;
                    SessMarks.value = "0";
                    SessMarks.disabled = true;
                    if (chkPaper1 != null) {
                        chkPaper1.checked = false;
                        chkPaper1.disabled = true;
                    }
                    if (chkPaper2 != null) {
                        chkPaper2.checked = false;
                        chkPaper2.disabled = true;
                    }
                    if (chkPaper3 != null) {
                        chkPaper3.checked = false;
                        chkPaper3.disabled = true;
                    }
                    if (chkPractical != null) {
                        chkPractical.checked = false;
                        chkPractical.disabled = true;
                    }
                    txtAmount.value = "0";
                } else if (CanResultStatusED.value == "Already PASS") {
                    if (chkPaper3 != null) {
                        chkPaper3.checked = false;
                        chkPaper3.disabled = true;
                    }
                } else if (CanResultStatusED.value == "0") {
                    if (chkPaper3 != null) {
                        chkPaper3.checked = false;
                        chkPaper3.disabled = false;
                    }
                } else {
                    CanEligibility.value = "for non-verification";
                    CanEligibility.disabled = false;
                    txtAmount.value = "0";
                }
            }
        }

        function CheckCanResultStatusPractical(thie) {
            debugger;
            var row = thie.parentNode.parentNode;
            var i = row.rowIndex - 1;
            var CanEligibility = document.getElementById('GridView1_ddlCanEligibility_' + i);
            var CanResultStatusED = document.getElementById('GridView1_ddlCanResultStatusED_' + i);
            var CanResultStatusPractical = document.getElementById('GridView1_ddlCanResultStatusPractical_' + i);
            var Attendance = document.getElementById('GridView1_ddlAttendance_' + i);
            var SessMarks = document.getElementById('GridView1_ddlSessMarks_' + i);

            var chkPaper1 = document.getElementById('GridView1_chkPaper1_' + i);
            var chkPaper2 = document.getElementById('GridView1_chkPaper2_' + i);
            var chkPaper3 = document.getElementById('GridView1_chkPaper3_' + i);
            var chkPractical = document.getElementById('GridView1_chkPractical_' + i);
            var txtAmount = document.getElementById('GridView1_txtAmount_' + i);
            var hdnPaper1fee = document.getElementById('GridView1_hdnPaper1fee_' + i);
            var hdnPaper2fee = document.getElementById('GridView1_hdnPaper2fee_' + i);
            var hdnPaper3fee = document.getElementById('GridView1_hdnPaper3fee_' + i);
            var hdnPracticalFees = document.getElementById('GridView1_hdnPracticalFees_' + i);
            var hdnexamtype = document.getElementById('hdnexamtype');
            var lblCLocked = document.getElementById('GridView1_lblCLocked_' + i);

            var hdnPaper1Status = document.getElementById('GridView1_hdnPaper1Status_' + i);
            var hdnPaper2Status = document.getElementById('GridView1_hdnPaper2Status_' + i);
            var hdnPaper3Status = document.getElementById('GridView1_hdnPaper3Status_' + i);
            var hdnPracticalStatus = document.getElementById('GridView1_hdnPracticalStatus_' + i);
            var hdnPaper1chk = document.getElementById('GridView1_hdnPaper1chk_' + i);
            var hdnPaper2chk = document.getElementById('GridView1_hdnPaper2chk_' + i);
            var hdnPaper3chk = document.getElementById('GridView1_hdnPaper3chk_' + i);
            var hdnPracticalchk = document.getElementById('GridView1_hdnPracticalchk_' + i);

            if (CanResultStatusED != null) {
                if (CanEligibility.value != "for verification") {
                    if (CanResultStatusED.value == "Already PASS" && CanResultStatusPractical.value == "Already PASS") {
                        CanEligibility.value = "for non-verification";
                        CanEligibility.disabled = true;
                        Attendance.value = "0";
                        Attendance.disabled = true;
                        SessMarks.value = "0";
                        SessMarks.disabled = true;
                        if (chkPaper1 != null) {
                            chkPaper1.checked = false;
                        }
                        chkPaper1.disabled = true;
                        if (chkPaper2 != null) {
                            chkPaper2.checked = false;
                            chkPaper2.disabled = true;
                        }
                        if (chkPaper3 != null) {
                            chkPaper3.checked = false;
                            chkPaper3.disabled = true;
                        }
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                        txtAmount.value = "0";
                    } else if (CanResultStatusPractical.value == "Already PASS") {
                        CanEligibility.disabled = false;
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                    } else if (CanResultStatusPractical.value == "0") {
                        CanEligibility.disabled = false;
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                        }
                        if (CanEligibility.value == "for non-verification") {
                            if (chkPractical != null) {
                                chkPractical.disabled = true;
                            }
                        }
                    } else {
                        CanEligibility.value = "for non-verification";
                        CanEligibility.disabled = false;
                        txtAmount.value = "0";
                    }
                } else if (CanEligibility.value == "for verification") {
                    if (CanResultStatusED.value == "Already PASS" && CanResultStatusPractical.value == "Already PASS") {
                        CanEligibility.value = "for non-verification";
                        CanEligibility.disabled = true;
                        Attendance.value = "0";
                        Attendance.disabled = true;
                        SessMarks.value = "0";
                        SessMarks.disabled = true;
                        if (chkPaper1 != null) {
                            chkPaper1.checked = false;
                            chkPaper1.disabled = true;
                        }
                        if (chkPaper2 != null) {
                            chkPaper2.checked = false;
                            chkPaper2.disabled = true;
                        }
                        if (chkPaper3 != null) {
                            chkPaper3.checked = false;
                            chkPaper3.disabled = true;
                        }
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                        txtAmount.value = "0";
                    } else if (CanResultStatusPractical.value == "Already PASS") {
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                    } else if (CanResultStatusPractical.value == "0") {
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = false;
                        }
                    } else {
                        CanEligibility.value = "for non-verification";
                        CanEligibility.disabled = false;
                        txtAmount.value = "0";
                    }
                }
            } else {
                if (CanEligibility.value != "for verification") {
                    if (CanResultStatusPractical.value == "Already PASS") {
                        CanEligibility.value = "for non-verification";
                        CanEligibility.disabled = true;
                        Attendance.value = "0";
                        Attendance.disabled = true;
                        SessMarks.value = "0";
                        SessMarks.disabled = true;
                        if (chkPaper1 != null) {
                            chkPaper1.checked = false;
                            chkPaper1.disabled = true;
                        }
                        if (chkPaper2 != null) {
                            chkPaper2.checked = false;
                            chkPaper2.disabled = true;
                        }
                        if (chkPaper3 != null) {
                            chkPaper3.checked = false;
                            chkPaper3.disabled = true;
                        }
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                        txtAmount.value = "0";
                    } else if (CanResultStatusPractical.value == "Already PASS") {
                        CanEligibility.disabled = false;
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                    } else if (CanResultStatusPractical.value == "0") {
                        CanEligibility.disabled = false;
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                        }
                        if (CanEligibility.value == "for non-verification") {
                            if (chkPractical != null) {
                                chkPractical.disabled = true;
                            }
                        }
                    } else {
                        CanEligibility.value = "for non-verification";
                        CanEligibility.disabled = false;
                        txtAmount.value = "0";
                    }
                } else if (CanEligibility.value == "for verification") {
                    if (CanResultStatusPractical.value == "Already PASS") {
                        CanEligibility.value = "for non-verification";
                        CanEligibility.disabled = true;
                        Attendance.value = "0";
                        Attendance.disabled = true;
                        SessMarks.value = "0";
                        SessMarks.disabled = true;
                        if (chkPaper1 != null) {
                            chkPaper1.checked = false;
                            chkPaper1.disabled = true;
                        }
                        if (chkPaper2 != null) {
                            chkPaper2.checked = false;
                            chkPaper2.disabled = true;
                        }
                        if (chkPaper3 != null) {
                            chkPaper3.checked = false;
                            chkPaper3.disabled = true;
                        }
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                        txtAmount.value = "0";
                    } else if (CanResultStatusPractical.value == "Already PASS") {
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = true;
                        }
                    } else if (CanResultStatusPractical.value == "0") {
                        if (chkPractical != null) {
                            chkPractical.checked = false;
                            chkPractical.disabled = false;
                        }
                    } else {
                        CanEligibility.value = "for non-verification";
                        CanEligibility.disabled = false;
                        txtAmount.value = "0";
                    }
                }
            }
        }
    </script>
</head>
<body style="font-family: Arial; font-size: 16px;">
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdateProgress ID="uprgsMaster" runat="server" DisplayAfter="1" DynamicLayout="false">
                <ProgressTemplate>
                    <div id="divprogress" align="center" style="width: 100%; height: 100%; min-height: 100%; position: fixed; z-index: 100002; top: 0px; left: 0px; background-color: Gray; filter: alpha(opacity=80); opacity: 0.8; z-index: 10000;">
                        <img id="Img1" alt="Wait" style="opacity: 1; margin-top: 250px;" runat="server" src="~/images/loader_transparent.gif" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table style="width: 100%; font-family: Arial; background-image: url('../images/back.jpg');"
                        cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="19" style="background-color: #cc632a; height: 5px;"></td>
                        </tr>
                        <tr>
                            <td colspan="20" style="background-color: #d8b377; height: 80px;">
                                <table style="width: 100%;">
                                    <tr>
                                        <td style="height: 45px; width: 14%;"></td>
                                        <td colspan="3" style="width: 25%;">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/iti.png" Height="75px" />
                                        </td>
                                        <td style="width: 22%;"></td>
                                        <td colspan="3" style="width: 25%;" align="center">
                                            <%--<asp:Image ID="Image2" runat="server" ImageUrl="~/images/Aptech.png" Height="70px"
                                        Width="200px" />--%>
                                        </td>
                                        <td style="width: 14%;"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr style="background-color: #cc632a; height: 25px;">
                            <td colspan="20" style="height: 25px; text-align: center;">
                                <asp:Label ID="lblUName" runat="server" Text="" Style="margin-left: 10%; font-weight: bold;"></asp:Label>
                                <asp:LinkButton ID="lnklogout" runat="server" OnClick="lnklogout_Click" Style="float: right; margin-right: 10%;">Logout</asp:LinkButton>
                            </td>
                        </tr>
                        <tr style="background-color: #d8b377; height: 25px;">
                            <td colspan="20" style="height: 25px; text-align: left; padding-left: 15%">Student Verifications
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" style="width: 0%;"></td>
                            <td colspan="14" rowspan="15">
                                <table style="width: 100%; border: none;">
                                    <tr>
                                        <td colspan="12"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 5%;"></td>
                                        <td colspan="10" rowspan="13">
                                            <table style="width: 100%; border: 1px solid grey; font-size: 14px; border-radius: 8px;"
                                                cellpadding="0" cellspacing="0">
                                                <tr style="background-color: #d8b377; height: 25px;">
                                                    <td style="width: 5%;"></td>
                                                    <td colspan="10" style="font-size: 15px; font-weight: bold;"></td>
                                                    <td style="width: 5%;"></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 5%; height: 18px;">&nbsp;
                                                    </td>
                                                    <td colspan="10">&nbsp;
                                                    </td>
                                                    <td style="width: 5%;">&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 25px;">
                                                        <asp:Label ID="lbladmYear" runat="server" Text="Admission Year :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlAdmissionYear" OnSelectedIndexChanged="ddlAdmissionYear_SelectedIndexChanged" AutoPostBack="True" runat="server" Width="200px" CssClass="ddlstyle">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="lblTradeName" runat="server" Text="Trade Name :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlTradeName" AppendDataBoundItems="false" runat="server" Width="200px" CssClass="ddlstyle">
                                                            <%--<asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="TTTT 243">TTTT 243</asp:ListItem>
                                                    <asp:ListItem Value="TTTT 241">TTTT 241</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <hr style="color: brown;" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 25px;">
                                                        <asp:Label ID="lblSemester" runat="server" Text="Semester :"></asp:Label>

                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlSemester" runat="server" Width="200px" CssClass="ddlstyle">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">Sem 1</asp:ListItem>
                                                            <asp:ListItem Value="2">Sem 2</asp:ListItem>
                                                            <asp:ListItem Value="3">Sem 3</asp:ListItem>
                                                            <asp:ListItem Value="4">Sem 4</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>


                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%;">
                                                        <asp:Label ID="lblExamType" runat="server" Text="Exam Type :"></asp:Label>
                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;">
                                                        <asp:DropDownList ID="ddlexamtype" runat="server" Width="200px" CssClass="ddlstyle">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="Reg">Reg</asp:ListItem>
                                                            <asp:ListItem Value="Ex">Ex</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                    <td colspan="10">
                                                        <hr style="color: brown;" />
                                                    </td>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>

                                                <tr id="tr_PaymentType" runat="server" visible="false">
                                                    <td style="vertical-align: middle; text-align: right;">
                                                        <span style="color: red;">*&nbsp;</span>
                                                    </td>
                                                    <td style="width: 15%; height: 25px;">
                                                        <asp:Label ID="Label1" runat="server" Text="Payment Type :"></asp:Label>

                                                    </td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlPaymentType" runat="server" Width="200px" CssClass="ddlstyle" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentType_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="dd">DD</asp:ListItem>
                                                            <asp:ListItem Value="online">Online</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td style="width: 2%; vertical-align: middle; text-align: right;" colspan="2"></td>
                                                    <td style="width: 15%;"></td>
                                                    <td style="width: 2%;"></td>
                                                    <td colspan="2" style="width: 27%;"></td>
                                                    <td></td>
                                                </tr>



                                                <tr>
                                                    <td></td>
                                                    <td style="height: 18px;">&nbsp;
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td colspan="7" align="center">
                                                        <asp:Button ID="btnSubmit" runat="server" Text="Search" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;"
                                                            OnClientClick="return FiltervalidationCheck();" OnClick="btnSubmit_Click" />&nbsp;
                                                        <%--<asp:Button ID="btnReport" runat="server" OnClick="btnReport_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="GenerateReport" Visible="false" Enabled="false" />--%>
                                            &nbsp;<asp:Button ID="btnExit" runat="server" Text="Exit" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClick="btnExit_Click" />
                                                    </td>
                                                    <td>
                                                        <asp:HiddenField ID="HiddenFieldLoginId" runat="server" />
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td align="center" colspan="7">&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                </tr>

                                                <tr>
                                                    <td colspan="11"></td>

                                                    <tr>
                                                        <td></td>
                                                        <td colspan="4" style="height: 25px; color: red; vertical-align: middle;">
                                                            <asp:Label ID="lblCMessage" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp; </td>
                                                        <td colspan="10">
                                                            <%--<div style="height: 250px; font-size: 12px;">--%>
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>


                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" OnRowDataBound="GridView1_RowDataBound" HeaderStyle-BackColor="#cc632a">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Roll No" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdntbledited" runat="server" Value='<%# Eval("isedited") %>' />
                                                                                    <asp:HiddenField ID="hdnPaymentStatus" runat="server" Value='<%# Eval("PaymentStatus") %>' />
                                                                                    <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("RollNumber") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Father's Name" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblFatherName" runat="server" Text='<%# Eval("FatherName") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date of Birth(DDMMYYYY)" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Candidate's Eligibility" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnCanEligibility" runat="server" Value='<%# Eval("Eligibility") %>'></asp:HiddenField>
                                                                                    <asp:Label ID="lblCanEligibility" runat="server" Text='<%# Eval("Eligibility") %>' Visible="false"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlCanEligibility" runat="server" onchange="CheckCanEligiblity(this)" Width="130px" CssClass="ddlstyle">
                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        <asp:ListItem Value="for verification">For Verification</asp:ListItem>
                                                                                        <asp:ListItem Value="for non-verification">For Non-Verification</asp:ListItem>
                                                                                        <asp:ListItem Value="discharge">Discharge</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Choice Locked" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblCLocked" runat="server" Text='<%# Eval("ChoiceLocked") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Attendance" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnAttendance" runat="server" Value='<%# Eval("Attendance") %>'></asp:HiddenField>
                                                                                    <asp:Label ID="lblAttendance" runat="server" Text='<%# Eval("Attendance") %>' Visible="false"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlAttendance" runat="server" Width="140px" CssClass="ddlstyle">
                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        <asp:ListItem Value="greater than or equal to 80%">Greater than or equal to 80%</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Sessional Marks" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnSessMarks" runat="server" Value='<%# Eval("Sessionalmarks") %>'></asp:HiddenField>
                                                                                    <asp:Label ID="lblSessMarks" runat="server" Text='<%# Eval("Sessionalmarks") %>' Visible="false"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlSessMarks" runat="server" Width="140px" CssClass="ddlstyle">
                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        <asp:ListItem Value="greater than or equal to 60% for practical and greater than or equal to 40% for theory">Greater than or equal to 60% for practical and greater than or equal to 40% for Theory</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Paper1" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnPaper1fee" runat="server" Value='<%# Eval("Paper1fee") %>'></asp:HiddenField>
                                                                                    <asp:HiddenField ID="hdnPaper1chk" runat="server" Value='<%# Eval("chkPaper1") %>'></asp:HiddenField>
                                                                                    <asp:CheckBox ID="chkPaper1" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper1")) %>' onchange="PaperAmountCalc(this);" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Paper2" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnPaper2fee" runat="server" Value='<%# Eval("Paper2fee") %>'></asp:HiddenField>
                                                                                    <asp:HiddenField ID="hdnPaper2chk" runat="server" Value='<%# Eval("chkPaper2") %>'></asp:HiddenField>
                                                                                    <asp:CheckBox ID="chkPaper2" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper2")) %>' onchange="PaperAmountCalc(this);" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Paper3" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnPaper3fee" runat="server" Value='<%# Eval("Paper3fee") %>'></asp:HiddenField>
                                                                                    <asp:HiddenField ID="hdnPaper3chk" runat="server" Value='<%# Eval("chkPaper3") %>'></asp:HiddenField>
                                                                                    <asp:CheckBox ID="chkPaper3" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper3")) %>' onchange="PaperAmountCalc(this);" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <%--<asp:TemplateField HeaderText="Trade Theory" ItemStyle-HorizontalAlign="Center">'<%# Eval("Paper1Header") %>'  '<%# Eval("Paper2Header") %>'
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="hdnTradeTheoryFees" runat="server" Value='<%# Eval("TradeTheoryFees") %>'></asp:HiddenField>
                                                                                <asp:CheckBox ID="chkTradeTheory" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("TradeTheory")) %>' onchange="PaperAmountCalc(this);" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employability Skills" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="hdnEmpSkillsFees" runat="server" Value='<%# Eval("EmpSkillsFees") %>'></asp:HiddenField>
                                                                                <asp:CheckBox ID="chkEmpSkills" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Employabilityskills")) %>' onchange="PaperAmountCalc(this);" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Workshop Calc & Science" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="hdnWorkshopCalcFees" runat="server" Value='<%# Eval("WorkshopCalcFees") %>'></asp:HiddenField>
                                                                                <asp:CheckBox ID="chkWorkshopCalc" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("WorkshopCalcScience")) %>' onchange="PaperAmountCalc(this);" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Engineering Drawing" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemTemplate>
                                                                                <asp:HiddenField ID="hdnEngDrawingFees" runat="server" Value='<%# Eval("EngDrawingFees") %>'></asp:HiddenField>
                                                                                <asp:CheckBox ID="chkEngDrawing" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("EngineeringDrawing")) %>' onchange="PaperAmountCalc(this);" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                            <asp:TemplateField HeaderText="Practical" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnPracticalFees" runat="server" Value='<%# Eval("PracticalFees") %>'></asp:HiddenField>
                                                                                    <asp:HiddenField ID="hdnPracticalchk" runat="server" Value='<%# Eval("chkpractical") %>'></asp:HiddenField>
                                                                                    <asp:CheckBox ID="chkPractical" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("practical")) %>' onchange="PaperAmountCalc(this);" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtAmount" runat="server" Style="color: black; margin-left: 20px; border: none" Enabled="false" BackColor="#ffffff" Text='<%# Eval("Amount") %>' Width="50px"></asp:TextBox>
                                                                                    <asp:HiddenField ID="hdnPaper1Status" runat="server" Value='<%# Eval("Paper1Status") %>'></asp:HiddenField>
                                                                                    <asp:HiddenField ID="hdnPaper2Status" runat="server" Value='<%# Eval("Paper2Status") %>'></asp:HiddenField>
                                                                                    <asp:HiddenField ID="hdnPaper3Status" runat="server" Value='<%# Eval("Paper3Status") %>'></asp:HiddenField>
                                                                                    <asp:HiddenField ID="hdnPracticalStatus" runat="server" Value='<%# Eval("PracticalStatus") %>'></asp:HiddenField>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Result Status ED" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnCanResultStatusED" runat="server" Value='<%# Eval("ResultStatusED") %>'></asp:HiddenField>
                                                                                    <asp:Label ID="lblCanResultStatusED" runat="server" Text='<%# Eval("ResultStatusED") %>' Visible="false"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlCanResultStatusED" runat="server" onchange="CheckCanResultStatusED(this)" Width="130px" CssClass="ddlstyle">
                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        <asp:ListItem Value="Already PASS">Already PASS</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Result Status Practical" ItemStyle-HorizontalAlign="Center">
                                                                                <ItemTemplate>
                                                                                    <asp:HiddenField ID="hdnCanResultStatusPractical" runat="server" Value='<%# Eval("ResultStatusPractical") %>'></asp:HiddenField>
                                                                                    <asp:Label ID="lblCanResultStatusPractical" runat="server" Text='<%# Eval("ResultStatusPractical") %>' Visible="false"></asp:Label>
                                                                                    <asp:DropDownList ID="ddlCanResultStatusPractical" runat="server" onchange="CheckCanResultStatusPractical(this)" Width="130px" CssClass="ddlstyle">
                                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        <asp:ListItem Value="Already PASS">Already PASS</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <div style="margin-top: 10px; float: right;" id="divtotal" runat="server" visible="false">
                                                                        Total no of students :
                                                                        <asp:Label ID="lbltotalstucount" runat="server" Text="0"></asp:Label>&nbsp;&nbsp
                                                                    Total Payment :
                                                                        <asp:Label ID="lbltotalstuPayment" runat="server" Text="0"></asp:Label>
                                                                    </div>
                                                                    <div style="margin-top: 30px;">
                                                                        <asp:HiddenField ID="hdnexamtype" runat="server" />
                                                                        <asp:HiddenField ID="hdnrows" runat="server" />
                                                                        <asp:Button ID="btnGridPrevious" runat="server" Text="Previous" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px; margin-right: 10px;" OnClick="btnGridPrevious_Click" Visible="false" />
                                                                        <asp:Button ID="btnGridNext" runat="server" Text="Save & Next" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" OnClientClick="return GridvalidationCheck();" OnClick="btnGridNext_Click" Visible="false" />
                                                                        <asp:Button ID="btnSave" runat="server" OnClientClick="return GridvalidationCheck();" OnClick="btnSave_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Save" Visible="false" />
                                                                    </div>
                                                                    <div style="margin-top: 30px; max-height: 800px; overflow-y: scroll;" runat="server" id="div_DDPayment" visible="false">
                                                                        <span style="font-weight: bold;">Pending DD Payment</span>
                                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" HeaderStyle-BackColor="#cc632a">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                                                                                    <HeaderTemplate>
                                                                                        <asp:CheckBox ID="checkAll" runat="server" AutoPostBack="true" OnCheckedChanged="checkAll_CheckedChanged" />
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="checkCan" runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Roll No" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("RollNumber") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Father's Name" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblFatherName" runat="server" Text='<%# Eval("FatherName") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Date of Birth(DDMMYYYY)" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDOB" runat="server" Text='<%# Eval("DOB") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Candidate's Eligibility" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblCanEligibility" runat="server" Text='<%# Eval("Eligibility") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Admission Year" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblAdmissionYear" runat="server" Text='<%# Eval("AdmissionYear") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Trade" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTrade" runat="server" Text='<%# Eval("Trade") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Semester" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblSemester" runat="server" Text='<%# Eval("Semester/Year") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Exam Type" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblExamtype" runat="server" Text='<%# Eval("Examtype") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Paper1" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkPaper1" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper1")) %>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Paper2" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkPaper2" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper2")) %>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Paper3" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkPaper3" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("Paper3")) %>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Practical" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="chkPractical" runat="server" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("practical")) %>' />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemTemplate>
                                                                                        <asp:TextBox ID="txtAmount" runat="server" Style="color: black; margin-left: 20px; border: none" Enabled="false" BackColor="#ffffff" Text='<%# Eval("Amount") %>' Width="50px"></asp:TextBox>
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" Font-Names="Arial" Font-Size="13px"></ItemStyle>
                                                                                    <HeaderStyle Font-Names="Arial" Font-Size="15px" />
                                                                                </asp:TemplateField>
                                                                            </Columns>

                                                                            <HeaderStyle BackColor="#CC632A"></HeaderStyle>
                                                                        </asp:GridView>
                                                                        <div style="margin-top: 10px; float: right;" id="divtotalDD" runat="server" visible="false">
                                                                            Total no of students :<asp:Label ID="lbltotalstucountDD" runat="server" Text="0"></asp:Label>&nbsp;&nbsp
                                                                    Total Payment :<asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                                                                        </div>
                                                                        <div style="margin-top: 30px;">
                                                                            <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" />
                                                                            <asp:Button ID="btnDDSave" runat="server" Text="Save & Next" OnClick="btnDDSave_Click" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" />
                                                                        </div>
                                                                    </div>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="GridView2" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                            <%--</div>--%>
                                                        </td>
                                                        <td>&nbsp; </td>
                                                    </tr>
                                                    <tr>
                                                        <td>&nbsp; </td>
                                                        <td style="height: 50px;" colspan="10" align="right">&nbsp; &nbsp;
                                                            
                                                           &nbsp;
                                                            <asp:Button ID="btnPrint" runat="server" Style="width: 125px; border-radius: 5px; background-color: #cc632a; color: white; font-weight: bold; height: 35px;" Text="Print" Visible="false" Enabled="false" />


                                                        </td>
                                                        <td>&nbsp; </td>
                                                    </tr>
                                                </tr>

                                            </table>
                                        </td>
                                        <td style="width: 5%;"></td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="3" style="width: 0%;"></td>
                        </tr>
                    </table>

                    <center>
                        <table runat="server" id="trPayment" visible="false" style="width: 60%; font-size: 16px; border-width: thin; border-color: black; height: 25px; display: none;" border="1" cellpadding="0" cellspacing="0">
                            <tr style="height: 25px; text-align: center; font-weight: bold;">
                                <td colspan="6" style="height: 25px; text-align: left; padding-left: 15%;">
                                    <center>
                                        Pending Payment Details
                                    </center>
                                </td>
                            </tr>
                            <tr style="height: 25px; text-align: center;">
                                <td width="19%">Payment Date:
                                </td>
                                <td style="background-color: lightgray">
                                    <asp:Label ID="lblPaymentDate" runat="server"></asp:Label>
                                </td>
                                <td>Payment Amount:
                                </td>
                                <td width="19%" style="background-color: lightgray">
                                    <asp:Label ID="lblPaymentAmount" runat="server"></asp:Label>
                                </td>
                                <td>Order No:
                                </td>
                                <td width="19%" style="background-color: lightgray">
                                    <asp:Label ID="lblOrderNo" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </center>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
