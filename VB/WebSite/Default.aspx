<%@ Page Language="vb" AutoEventWireup="true"  CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v21.2, Version=21.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web" TagPrefix="dxe" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v21.2, Version=21.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dxwpg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
	<div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
            SelectCommand="SELECT [Sales Person] AS Sales_Person, [Extended Price] AS Extended_Price, [CategoryName] FROM [SalesPerson]">

        </asp:SqlDataSource>

        <dxwpg:ASPxPivotGrid ID="pivot" runat="server" ClientInstanceName="pivot" 
            DataSourceID="SqlDataSource1" 
            oncustomcallback="OnASPxPivotGridCustomCallback" 
            oncustomcellstyle="OnASPxPivotGridCustomCellStyle" ClientIDMode="AutoID" IsMaterialDesign="False">
            <Fields>
                <dxwpg:PivotGridField ID="fieldSalesPerson" Area="RowArea" AreaIndex="0">
                    <DataBindingSerializable>
                        <dxwpg:DataSourceColumnBinding ColumnName="Sales_Person" />
                    </DataBindingSerializable>
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="fieldExtendedPrice" Area="DataArea" AreaIndex="0">
                    <DataBindingSerializable>
                        <dxwpg:DataSourceColumnBinding ColumnName="Extended_Price" />
                    </DataBindingSerializable>
                </dxwpg:PivotGridField>
                <dxwpg:PivotGridField ID="fieldCategoryName" Area="ColumnArea" AreaIndex="0">
                    <DataBindingSerializable>
                        <dxwpg:DataSourceColumnBinding ColumnName="CategoryName" />
                    </DataBindingSerializable>
                </dxwpg:PivotGridField>
            </Fields>
            <ClientSideEvents CellClick="function(s, e) {
	pivot.PerformCallback(&quot;SC|&quot; + e.ColumnIndex + &quot;|&quot; + e.RowIndex);
}" />
            <OptionsData DataProcessingEngine="Optimized" />
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