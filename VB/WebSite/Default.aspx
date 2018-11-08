<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
				<asp:AccessDataSource ID="AccessDataSource1" runat="server" 
			DataFile="~/App_Data/nwind.mdb" 
			SelectCommand="SELECT [Sales Person] AS Sales_Person, [Extended Price] AS Extended_Price, [CategoryName] FROM [SalesPerson]">
		</asp:AccessDataSource>
		<dxwpg:ASPxPivotGrid ID="pivot" runat="server" ClientInstanceName="pivot" 
			DataSourceID="AccessDataSource1" 
			oncustomcallback="OnASPxPivotGridCustomCallback" 
			oncustomcellstyle="OnASPxPivotGridCustomCellStyle">
			<Fields>
				<dxwpg:PivotGridField ID="fieldSalesPerson" Area="RowArea" AreaIndex="0" 
					FieldName="Sales_Person">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldExtendedPrice" Area="DataArea" AreaIndex="0" 
					FieldName="Extended_Price">
				</dxwpg:PivotGridField>
				<dxwpg:PivotGridField ID="fieldCategoryName" Area="ColumnArea" AreaIndex="0" 
					FieldName="CategoryName">
				</dxwpg:PivotGridField>
			</Fields>
			<ClientSideEvents CellClick="function(s, e) {
	pivot.PerformCallback(&quot;SC|&quot; + e.ColumnIndex + &quot;|&quot; + e.RowIndex);
}" />
		</dxwpg:ASPxPivotGrid>
		<dxe:ASPxComboBox ID="selectionTypeCombo" runat="server" SelectedIndex="0" 
			ValueType="System.String">
			<Items>
				<dxe:ListEditItem Text="Row Selection" Value="Row Selection" />
				<dxe:ListEditItem Text="Column Selection" Value="Column Selection" />
			</Items>
		</dxe:ASPxComboBox>
	</div>
	</form>
</body>
</html>