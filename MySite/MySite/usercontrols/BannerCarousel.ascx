<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BannerCarousel.ascx.cs" Inherits="Easyway.usercontrols.BannerCarousel1" %>

 <script>
function fnCarousel()
{
   $(document).ready(function() {
   $('.jcarousel')

    // Bind first
    .jcarousel({wrap: 'circular'})
    .on('jcarouselautoscroll:create', function(event, carousel) {
        // Do something
    })
    // Initialize at last step
    .jcarouselAutoscroll();
   });
 }  
   </script>			

 
 <div id="divCarousel" runat="server"></div>    
