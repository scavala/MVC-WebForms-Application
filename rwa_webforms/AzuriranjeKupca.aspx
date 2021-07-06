<%@ Page Title="Azuriranje kupca" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AzuriranjeKupca.aspx.cs" Inherits="rwa_webforms.AzuriranjeKupca" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row">
        <div class="col-md-8">
            <asp:GridView class="table table-hover table-striped" OnPageIndexChanging="gvKupci_PageIndexChanging" AllowSorting="True"
                OnSorting="gvKupci_Sorting" ID="gvKupci" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" DataKeyNames="IDKupac" OnSelectedIndexChanging="gvKupci_SelectedIndexChanging" AllowPaging="True" PageSize="20" Caption="Kupci">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:CommandField CancelText="Odustani" SelectText="Odaberi" ShowSelectButton="True" />
                    <asp:BoundField DataField="IDKupac" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="Ime" HeaderText="IME" SortExpression="Ime" ReadOnly="True" />
                    <asp:BoundField DataField="Prezime" HeaderText="PREZIME" SortExpression="Prezime" />
                    <asp:TemplateField HeaderText="E-mail">
                        <ItemTemplate>
                            <a href="mailto:<%# Eval("Email") %>"><%# Eval("Email") %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Telefon" HeaderText="TELEFON" />
                    <asp:TemplateField HeaderText="Naziv grada">
                        <ItemTemplate>
                            <asp:Label
                                ID="lblGradNaziv"
                                runat="server"
                                Text='<%# GetNazivGradaFromID(Eval("GradID")) %>'>
                            </asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <PagerSettings Mode="NextPrevious" PreviousPageText="previous 	&nbsp; " NextPageText="next &nbsp;" LastPageText="" />
            </asp:GridView>
        </div>

        <div class="col-md-4">
            <br />
            <asp:Label ID="lblInfo" runat="server" Font-Bold="True" Font-Size="12px" ForeColor="Red"></asp:Label>

            <asp:Label ID="lblDdlbrojkupaca" AssociatedControlID="ddlKupacaPoStranici" Text="Broj kupaca po stranici:" runat="server" />

            <asp:DropDownList ID="ddlKupacaPoStranici"
                OnSelectedIndexChanged="ddlKupacaPoStranici_SelectedIndexChanged"
                AutoPostBack="true"
                runat="server">

                <asp:ListItem Value="10"> 10 </asp:ListItem>
                <asp:ListItem Selected="True" Value="20"> 20 </asp:ListItem>
                <asp:ListItem Value="30"> 30 </asp:ListItem>
                <asp:ListItem Value="40"> 40 </asp:ListItem>
                <asp:ListItem Value="50"> 50 </asp:ListItem>

            </asp:DropDownList>
            <br />

            <asp:Label ID="lblFiltriranjeKupaca" AssociatedControlID="lblDrzaveFilterBroj" Text="Filtriranje kupaca:" runat="server" /><br />

            <asp:Label ID="lblDrzaveFilterBroj" AssociatedControlID="ddlDrzaveFilter" Text="Država:" runat="server" />
            <asp:DropDownList CssClass="form-control" ID="ddlDrzaveFilter" OnSelectedIndexChanged="ddlDrzaveFilter_SelectedIndexChanged"
                AutoPostBack="true"
                runat="server">
            </asp:DropDownList>

            <asp:Label ID="lblGradoviFilterBroj" AssociatedControlID="ddlGradoviFilter" Text="Grad:" runat="server" />
            <asp:DropDownList CssClass="form-control" ID="ddlGradoviFilter" OnSelectedIndexChanged="ddlGradoviFilter_SelectedIndexChanged" AutoPostBack="true"
                runat="server">
            </asp:DropDownList>
            <br />

            <asp:Label ID="lblAzuriranjelabel" AssociatedControlID="lblTbKupac" Text="Ažuriranje podataka kupaca:" runat="server" /><br />


            <asp:Label ID="lblTbKupac" AssociatedControlID="txtIDKUPAC" Text="ID:" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtIDKUPAC" runat="server" ReadOnly="True"></asp:TextBox>

            <asp:Label ID="lblTbIme" AssociatedControlID="txtIme" Text="Ime:" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtIme" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorIme"
                ControlToValidate="txtIme"
                Display="Dynamic" ErrorMessage="Ovo polje je obavezno!" Font-Bold="True" ForeColor="Red"
                runat="server" /><br />

            <asp:Label ID="lblTbPrezime" AssociatedControlID="txtPrezime" Text="Prezime:" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtPrezime" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPrezime"
                ControlToValidate="txtPrezime"
                Display="Dynamic" ErrorMessage="Ovo polje je obavezno!" Font-Bold="True" ForeColor="Red"
                runat="server" />
            <br />

            <asp:Label ID="lblTbEmail" AssociatedControlID="txtEmail" Text="E-mail:" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Krivo upisana E-mail adresa!" Font-Bold="True" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail"
                ControlToValidate="txtEmail"
                Display="Dynamic" ErrorMessage="Ovo polje je obavezno!" Font-Bold="True" ForeColor="Red"
                runat="server" />
            <br />
            <asp:Label ID="lblTbTelefon" AssociatedControlID="txtTelefon" Text="Telefon:" runat="server" />
            <asp:TextBox CssClass="form-control" ID="txtTelefon" runat="server"></asp:TextBox>


            <asp:Label ID="lblDdlDrzave" AssociatedControlID="ddlDrzave" Text="Država:" runat="server" />
            <asp:DropDownList CssClass="form-control" ID="ddlDrzave" OnSelectedIndexChanged="ddlDrzave_SelectedIndexChanged"
                AutoPostBack="true"
                runat="server">
            </asp:DropDownList>

            <asp:Label ID="lblDdlGradovi" AssociatedControlID="ddlGradovi" Text="Grad:" runat="server" />
            <asp:DropDownList CssClass="form-control" ID="ddlGradovi"
                runat="server">
            </asp:DropDownList>
            <br />

            <asp:Button class="btn btn-primary" Text="Ažuriraj" runat="server" ID="btnAzuriraj" OnClick="btnAzuriraj_Click" />
        </div>

    </div>

    <hr />
    <asp:GridView ID="gvRacuni" class="table table-hover table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="IDRacun" DataSourceID="SqlDataSourceRacuni" AllowPaging="True" PageSize="15" Caption="Računi odabranog kupca">
        <Columns>
            <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            <asp:BoundField DataField="IDRacun" HeaderText="IDRacun" ReadOnly="True" InsertVisible="False"></asp:BoundField>
            <asp:BoundField DataField="DatumIzdavanja" HeaderText="DatumIzdavanja"></asp:BoundField>
            <asp:BoundField DataField="BrojRacuna" HeaderText="BrojRacuna"></asp:BoundField>
            <asp:BoundField DataField="KreditnaKarticaID" HeaderText="KreditnaKarticaID"></asp:BoundField>

            <asp:TemplateField HeaderText="Komercijalist">

                <ItemTemplate>
                    <asp:Label
                        ID="lblKomercijalistNaziv"
                        runat="server"
                        Text='<%# GetImeKomercijalistaFromID(Eval("KomercijalistID")) %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Tip kartice">

                <ItemTemplate>
                    <asp:Label
                        ID="lblTipKartice"
                        runat="server"
                        Text='<%# GetKreditnaKarticaFromID(Eval("KreditnaKarticaID")) %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <PagerSettings Mode="NextPrevious" PreviousPageText="previous 	&nbsp; " NextPageText="next" LastPageText="" />

    </asp:GridView>

    <asp:GridView class="table table-hover table-striped" runat="server" DataSourceID="SqlDataSourceStavke" AutoGenerateColumns="False" DataKeyNames="IDStavka" AllowPaging="True" PageSize="15" Caption="Stavke odabranog računa">
        <Columns>
            <asp:BoundField DataField="IDStavka" HeaderText="IDStavka" ReadOnly="True" InsertVisible="False"></asp:BoundField>
            <asp:BoundField DataField="RacunID" HeaderText="RacunID"></asp:BoundField>
            <asp:BoundField DataField="Kolicina" HeaderText="Kolicina"></asp:BoundField>

            <asp:TemplateField HeaderText="Proizvod">
                <ItemTemplate>
                    <asp:Label
                        ID="lblProizvodNaziv"
                        runat="server"
                        Text='<%# GetNazivProizvodaFromID(Eval("ProizvodID")) %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="CijenaPoKomadu" HeaderText="Cijena po komadu (HRK)"></asp:BoundField>
            <asp:BoundField DataField="PopustUPostocima" HeaderText="Popustu u postocima"></asp:BoundField>
            <asp:BoundField DataField="UkupnaCijena" HeaderText="Ukupna Cijena (HRK)"></asp:BoundField>
        </Columns>
        <PagerSettings Mode="NextPrevious" PreviousPageText="previous 	&nbsp; " NextPageText="next" LastPageText="" />
    </asp:GridView>

    <asp:SqlDataSource runat="server" ID="SqlDataSourceStavke" ConnectionString='<%$ ConnectionStrings:cs %>' SelectCommand="SELECT * FROM [Stavka] WHERE ([RacunID] = @RacunID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="gvRacuni" PropertyName="SelectedValue" DefaultValue="0" Name="RacunID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource runat="server" ID="SqlDataSourceRacuni" ConnectionString='<%$ ConnectionStrings:cs %>' SelectCommand="SELECT [IDRacun], [DatumIzdavanja], [BrojRacuna], [KreditnaKarticaID], [KomercijalistID] FROM [Racun] WHERE ([KupacID] = @KupacID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtIDKUPAC" PropertyName="Text" DefaultValue="" Name="KupacID" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>
