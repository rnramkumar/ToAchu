<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Reviews.ascx.cs" Inherits="Easyway.usercontrols.Reviews" %>

<div id="divLoading"></div>
<div id="divMsg"></div>
<div id="addReviewDiv">
    <a name="writereview"></a>
    <div>
        <h1 class="float-left">
                        &nbsp;Write a review
                    </h1>
    </div>
    <div> All fields are mandatory </div>
    
    <table id="user-review-form">
        <tbody><tr>
            <td>
                <label for="review_title">
                    
                    Review Title:</label>
            </td>
            <td >
                <input type="text" size="40" id="txtTitle" name="txtTitle" runat="server" maxlength="20" /><asp:RequiredFieldValidator 
                    ID="rfvTitle" runat="server" ControlToValidate="txtTitle" ErrorMessage="*"></asp:RequiredFieldValidator>
&nbsp;<div>
                    (Maximum 20 words)
                </div>
            </td>
        </tr>
        <tr>
            <td >

                <label for="review_text">
                    
                    Your Review:
                </label>

            </td>
            <td >
                <div >
                    <textarea rows="5" cols="30" id="txtReviewText" name="txtReviewText" runat="server" onkeydown="limitText(this,'span1','100');" onkeyup="limitText(this,'span1','100');"></textarea><asp:RequiredFieldValidator ID="rfvReview" 
                        runat="server" ControlToValidate="txtReviewText" ErrorMessage="*"></asp:RequiredFieldValidator>
                   <span id='span1'>0</span>characters used
                    <div>
                        (Please make sure your review contains at least 100 characters.)
                    </div>
                </div>


            </td>
        </tr>
        <tr>
            <td>
                <label >
                    
                    Your Rating:
                </label>
            </td>
            <td>
                
                
                <div class="ratethis"><span class="fl">Rate</span>
                    <ul class="star-rating">
                        <li id="liRating" class="current-rating"></li>
                        <li><a title="Poor" value="1" class="one-star" href="javascript:void(0);" onclick="javascript:setRating(this)">1</a></li>
                        <li><a title="OK" value="2" class="two-stars" href="javascript:void(0);" onclick="javascript:setRating(this)">2</a></li>
                        <li><a title="Good" value="3" class="three-stars" href="javascript:void(0);" onclick="javascript:setRating(this)">3</a></li>
                        <li><a title="Useful" value="4" class="four-stars" href="javascript:void(0);" onclick="javascript:setRating(this)">4</a></li>
                        <li><a title="Excellent" value="5" class="five-stars" href="javascript:void(0);" onclick="javascript:setRating(this)">5</a></li>
                    </ul>
                    
              </div><asp:RequiredFieldValidator ID="rfvRate" runat="server" ControlToValidate="txtRateValidate" ErrorMessage="*"></asp:RequiredFieldValidator>
               <input readonly type="text" name="txtRateValidate" id="txtRateValidate" runat="server" maxlength="1" style="width:1px;border:0" />
                    <div class="help_message lpadding5">
                        (Click to rate on scale of 1-5)
                    </div>
                
            </td>
        </tr>
                <tr>
            <td>
                <label for="display_name">
                
                    Your
                
                    Name
                </label>
            </td>
            <td >
                <input size="40" type="text" id="txtName" name="txtName" runat="server" maxlength="50" /><asp:RequiredFieldValidator 
                    ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
             <tr>
            <td>&nbsp;</td>
            <td>
                <input type="hidden" name="hdnRating" id="hdnRating" />
               <input type="button" ID="btnSubmit" value="Submit >>" OnClick="submitReview();" />
            </td>
        </tr>
               <tr>
            <td colspan="2"><a href='javascript:void(0)' onclick="javascript:readReview();"> Read Reviews</a> </td>
            </tr>
            <tr>
            <td colspan="2">
             <div id="divReview"></div>
            </td>
        </tr>
    </tbody></table>
</div>
<p>
    &nbsp;</p>
