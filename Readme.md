# How to highlight rows or columns by clicking on the field value


<p>This example demonstrates how to implement a feature similar to the one implemented in the PivotGridControl. When the user clicks within the field value, corresponding rows or columns are highlighted.</p><p>To implement this feature, the ASPxLabelControl is added to the Field Value Template. The ASPxLabelControl handles the client side Click event, and sends the callback to save the value and area of the Field Value that is being clicked. The value and area are used within the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomCellStyletopic"><u>ASPxPivotGrid.CustomCellStyle</u></a> event handler, to determine whether the current cell belongs to the selected row or column.</p>

<br/>


