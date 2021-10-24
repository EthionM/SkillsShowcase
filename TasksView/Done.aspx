<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Done.aspx.cs" Inherits="SkillsShowcase.Tasks.Done" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style type="text/css">
        .TaskDone{
            width:50%;
            background-color:#808e95;
            border: solid 1px gray;
        }
        .TaskTitle
        {
            font-size:20px;
            font-weight: bold;
            font-family: Arial, Helvetica, sans-serif;
            padding-left: 10px;
        }
        .TaskDescription
        {
            font-size:18px;
            font-family: Arial, Helvetica, sans-serif;
            padding-left: 5px;
        }
    </style>
    <asp:Repeater runat="server" ID="rptDoneTasks">
        <ItemTemplate>
            <div class="TaskDone">
                <table>
                    <tr>
                        <td style="height:65%; width:80%;">
                            <asp:Label Text='<%# Eval("Title") %>' runat="server" CssClass="TaskTitle"/>
                        </td>
                        <td style="width:100px;">
                            <div>
                            <label>Added</label>
                            </div>
                            <div>
                            <asp:Label Text='<%# Eval("DateAdded","{0:dd/M/yyyy}") %>' style="text-decoration:none;" runat="server" />
                            </div>
                        </td>
                        <td style="width:100px; padding-left:5px;">
                            <div>
                            <label>Finished</label>
                            </div>
                            <div>
                            <asp:Label Text='<%# Eval("DateFinished","{0:dd/M/yyyy}") %>' style="text-decoration:none;" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr id="trDescription" runat="server">
                        <td colspan="3" style="style=height:50px;max-width: 500px;">
                            <asp:Label Text='<%# Eval("Description") %>' CssClass="TaskDescription" runat="server" style="word-wrap: break-word;" />                        
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>

    </asp:Repeater>
</asp:Content>
