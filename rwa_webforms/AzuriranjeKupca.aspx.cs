using DAL;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace rwa_webforms
{

    public partial class AzuriranjeKupca : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Context.User.Identity.GetUserName() == String.Empty) Response.Redirect("Default.aspx");

            if (!IsPostBack)
            {
                GridViewDataBind();
                gvKupci_SelectedIndexChanging(null, new GridViewSelectEventArgs(0));

                try
                {
                    fillDdlDrzaveFilter();

                }
                catch (Exception ex)
                {
                    lblInfo.Text = ex.Message;
                }

            }

        }

        private void fillDdlDrzaveFilter()
        {
            ddlDrzaveFilter.DataSource = Repozitorij.GetDrzave();
            ddlDrzaveFilter.DataTextField = "Naziv";
            ddlDrzaveFilter.DataValueField = "IDDrzava";
            ddlDrzaveFilter.DataBind();
            ddlDrzaveFilter.Items.Add(new ListItem("--Odaberite državu--", "0"));
            ddlDrzaveFilter.SelectedValue = "0";
        }

        private void GridViewDataBind()
        {

            try
            {
                gvKupci.DataSource = Repozitorij.GetKupci();
                gvKupci.DataBind();
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }
        protected void gvKupci_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int indexRetka = e.NewSelectedIndex;
            int kupacID = (int)gvKupci.DataKeys[indexRetka].Value;
            try
            {
                fillDdlDrzave();

                Kupac k = Repozitorij.GetOdabraniKupac(kupacID);
                txtIme.Text = k.Ime;
                txtPrezime.Text = k.Prezime;
                txtEmail.Text = k.Email;
                txtTelefon.Text = k.Telefon;
                txtIDKUPAC.Text = kupacID.ToString();
                if (k.GradID != 0)
                {

                    ddlDrzave.SelectedValue = Repozitorij.GetGrad(k.GradID).DrzavaID.ToString();
                    RefreshDDLgradovi(ddlGradovi, ddlDrzave);
                    ddlGradovi.SelectedValue = k.GradID.ToString();

                }
            }
            catch (Exception ex)
            {

                lblInfo.Text = ex.Message;
            }
        }

        private void fillDdlDrzave()
        {
            ddlDrzave.Items.Clear();
            ddlDrzave.DataSource = Repozitorij.GetDrzave();
            ddlDrzave.DataTextField = "Naziv";
            ddlDrzave.DataValueField = "IDDrzava";
            ddlDrzave.DataBind();
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }
        protected void gvKupci_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                List<Kupac> listasort;
                var gradIDfilter = ddlGradoviFilter.SelectedValue;

                if (GridViewSortDirection == SortDirection.Ascending)
                {
                    GridViewSortDirection = SortDirection.Descending;
                    listasort = Repozitorij.GetKupci().Where(k => k.GradID.ToString() == ddlGradoviFilter.SelectedValue || string.IsNullOrEmpty(ddlGradoviFilter.SelectedValue)).OrderBy(k => k[e.SortExpression]).ToList();
                }
                else
                {
                    GridViewSortDirection = SortDirection.Ascending;
                    listasort = Repozitorij.GetKupci().Where(k => k.GradID.ToString() == ddlGradoviFilter.SelectedValue || string.IsNullOrEmpty(ddlGradoviFilter.SelectedValue)).OrderByDescending(k => k[e.SortExpression]).ToList();
                }

                gvKupci.DataSource = listasort;
                gvKupci.DataBind();

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
        }


        protected void gvKupci_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            try
            {
                gvKupci.PageIndex = e.NewPageIndex;
                if (ddlGradoviFilter.SelectedValue != "0")
                {
                    gvKupci.DataSource = Repozitorij.GetKupci().Where(k => k.GradID.ToString() == ddlGradoviFilter.SelectedValue || string.IsNullOrEmpty(ddlGradoviFilter.SelectedValue)
                    ).OrderBy(k => k.IDKupac).ToList();
                }
                else
                {
                    gvKupci.DataSource = Repozitorij.GetKupci().Where(k => Repozitorij.GetGrad(k.GradID).DrzavaID.ToString() == ddlDrzaveFilter.SelectedValue || string.IsNullOrEmpty(ddlDrzaveFilter.SelectedValue)
).OrderBy(k => k.IDKupac).ToList();
                }
                gvKupci.DataBind();

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }

        }

        protected void ddlDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RefreshDDLgradovi(ddlGradovi, ddlDrzave);
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }

        }

        private void RefreshDDLgradovi(DropDownList ddlGrad, DropDownList ddlDrzava)
        {
            ddlGrad.DataSource = Repozitorij.GetGradoviIzDrzave(int.Parse(ddlDrzava.SelectedValue));
            ddlGrad.DataTextField = "Naziv";
            ddlGrad.DataValueField = "IDGrad";
            ddlGrad.DataBind();

            if (ddlGrad == ddlGradoviFilter)
            {
                ddlGrad.Items.Add(new ListItem("--Odaberite grad--", "0"));
                ddlGrad.SelectedValue = "0";
            }
        }

        protected void btnAzuriraj_Click(object sender, EventArgs e)
        {
            if (txtIDKUPAC.Text == string.Empty) return;
            Kupac k = GetKupacFromForm();

            try
            {
                Repozitorij.UpdateKupac(k);
            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }

            GridViewDataBind();
            ddlDrzaveFilter.SelectedValue = "0";
            RefreshDDLgradovi(ddlGradoviFilter, ddlDrzaveFilter);

        }

        private Kupac GetKupacFromForm()
        {
            Kupac k = new Kupac();
            k.IDKupac = int.Parse(txtIDKUPAC.Text);
            k.Ime = txtIme.Text;
            k.Prezime = txtPrezime.Text;
            k.Email = txtEmail.Text;
            k.Telefon = txtTelefon.Text;
            k.GradID = int.Parse(ddlGradovi.SelectedValue);
            return k;
        }

        protected void ddlKupacaPoStranici_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvKupci.PageSize = int.Parse(ddlKupacaPoStranici.SelectedValue);
            ddlDrzaveFilter.SelectedValue = "0";
            RefreshDDLgradovi(ddlGradoviFilter, ddlDrzaveFilter);

            GridViewDataBind();
        }

        protected string GetImeKomercijalistaFromID(object id)
        {
            string t;
            int.TryParse(id.ToString(), out int k);
            try
            {
                t = Repozitorij.GetKomercijalist(k).PunoIme;

            }
            catch (Exception ex)
            {
                t = String.Empty;
                lblInfo.Text = ex.Message;
            }
            return t;
        }

        protected string GetNazivGradaFromID(object id)
        {
            string t;
            int.TryParse(id.ToString(), out int k);
            try
            {
                t = Repozitorij.GetGrad(k).Naziv;
            }
            catch (Exception ex)
            {

                t = String.Empty;
                lblInfo.Text = ex.Message;
            }
            return t;
        }

        protected string GetNazivProizvodaFromID(object id)
        {
            string t;
            int.TryParse(id.ToString(), out int k);
            try
            {
                t = Repozitorij.GetNazivProizvoda(k);
            }
            catch (Exception ex)
            {

                t = String.Empty;
                lblInfo.Text = ex.Message;
            }
            return t;
        }

        protected string GetKreditnaKarticaFromID(object id)
        {
            string t;
            int.TryParse(id.ToString(), out int k);
            try
            {
                t = Repozitorij.GetKreditnaKartica(k).Tip;
            }
            catch (Exception ex)
            {

                t = String.Empty;
                lblInfo.Text = ex.Message;
            }
            return t;
        }

        protected void ddlDrzaveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDDLgradovi(ddlGradoviFilter, ddlDrzaveFilter);

            if (ddlDrzaveFilter.SelectedValue != "0")
            {
                ddlGradoviFilter_SelectedIndexChanged(null, null);
            }
            else
            {
                GridViewDataBind();
            }
        }

        protected void ddlGradoviFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (ddlGradoviFilter.SelectedValue == "0")
                {
                    gvKupci.DataSource = Repozitorij.GetKupci().Where(kupac => Repozitorij.GetGrad(kupac.GradID).DrzavaID == int.Parse(ddlDrzaveFilter.SelectedValue)).ToList();
                }
                else
                {
                    gvKupci.DataSource = Repozitorij.GetKupci().Where(kupac => kupac.GradID == int.Parse(ddlGradoviFilter.SelectedValue)).ToList();
                }

            }
            catch (Exception ex)
            {
                lblInfo.Text = ex.Message;
            }
            gvKupci.DataBind();

        }
    }
}
