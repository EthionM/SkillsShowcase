<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Done.aspx.cs" Inherits="SkillsShowcase.Tasks.Done" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater runat="server" ID="rptDoneTasks">
        <ItemTemplate>
            <table>
                <tr>
                    <td style="width:90%;">
                        <asp:Label Text='<%# Eval("Title") %>' runat="server" />
                    </td>
                    <td style="width:10%;">
                        <asp:Label Text='<%# Eval("DateFinished") %>' runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label Text='<%# Eval("Description") %>' runat="server" />                        
                    </td>
                </tr>
            </table>
        </ItemTemplate>

    </asp:Repeater>
</asp:Content>
