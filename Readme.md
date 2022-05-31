<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2088)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to highlight rows or columns by clicking on the field value
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e2088/)**
<!-- run online end -->


<p>This example demonstrates how to implement a feature similar to the one implemented in the PivotGridControl. When the user clicks within the field value, corresponding rows or columns are highlighted.</p><p>To implement this feature, the ASPxLabelControl is added to the Field Value Template. The ASPxLabelControl handles the client side Click event, and sends the callback to save the value and area of the Field Value that is being clicked. The value and area are used within the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomCellStyletopic"><u>ASPxPivotGrid.CustomCellStyle</u></a> event handler, to determine whether the current cell belongs to the selected row or column.</p>

<br/>


