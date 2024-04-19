$(document).ready(function()
{
  $("#mayoria_edad").click(function(event)
  {
    if($("mayoria_edad").attr("checked"))
	{
	  $("formulariomayores").css("display", "block");
	}
	else
	{
	   $("formulariomayores").css("display", "none");
	}
  }
  );
});

$(document).ready(function()
{
 $("#test").click(function()
 {
   $("passito").css("display", "block");
 });
});


