using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MixERP.Net.ApplicationState.Cache;
using MixERP.Net.Common.Extensions;
using MixERP.Net.EntityParser;
using Newtonsoft.Json;
using PetaPoco;

namespace MixERP.Net.Api.Policy
{
    /// <summary>
    ///     Provides a direct HTTP access to perform various tasks such as adding, editing, and removing Store Policy Details.
    /// </summary>
    [RoutePrefix("api/v1.5/policy/store-policy-detail")]
    public class StorePolicyDetailController : ApiController
    {
        /// <summary>
        ///     The StorePolicyDetail data context.
        /// </summary>
        private readonly MixERP.Net.Schemas.Policy.Data.StorePolicyDetail StorePolicyDetailContext;

        public StorePolicyDetailController()
        {
            this.LoginId = AppUsers.GetCurrent().View.LoginId.ToLong();
            this.UserId = AppUsers.GetCurrent().View.UserId.ToInt();
            this.OfficeId = AppUsers.GetCurrent().View.OfficeId.ToInt();
            this.Catalog = AppUsers.GetCurrentUserDB();

            this.StorePolicyDetailContext = new MixERP.Net.Schemas.Policy.Data.StorePolicyDetail
            {
                Catalog = this.Catalog,
                LoginId = this.LoginId
            };
        }

        public long LoginId { get; }
        public int UserId { get; private set; }
        public int OfficeId { get; private set; }
        public string Catalog { get; }

        /// <summary>
        ///     Counts the number of store policy details.
        /// </summary>
        /// <returns>Returns the count of the store policy details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("count")]
        [Route("~/api/policy/store-policy-detail/count")]
        public long Count()
        {
            try
            {
                return this.StorePolicyDetailContext.Count();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Returns an instance of store policy detail.
        /// </summary>
        /// <param name="storePolicyDetailId">Enter StorePolicyDetailId to search for.</param>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("{storePolicyDetailId}")]
        [Route("~/api/policy/store-policy-detail/{storePolicyDetailId}")]
        public MixERP.Net.Entities.Policy.StorePolicyDetail Get(long storePolicyDetailId)
        {
            try
            {
                return this.StorePolicyDetailContext.Get(storePolicyDetailId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        [AcceptVerbs("GET", "HEAD")]
        [Route("get")]
        [Route("~/api/policy/store-policy-detail/get")]
        public IEnumerable<MixERP.Net.Entities.Policy.StorePolicyDetail> Get([FromUri] long[] storePolicyDetailIds)
        {
            try
            {
                return this.StorePolicyDetailContext.Get(storePolicyDetailIds);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 store policy details on each page, sorted by the property StorePolicyDetailId.
        /// </summary>
        /// <returns>Returns the first page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("")]
        [Route("~/api/policy/store-policy-detail")]
        public IEnumerable<MixERP.Net.Entities.Policy.StorePolicyDetail> GetPagedResult()
        {
            try
            {
                return this.StorePolicyDetailContext.GetPagedResult();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a paginated collection containing 25 store policy details on each page, sorted by the property StorePolicyDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <returns>Returns the requested page from the collection.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("page/{pageNumber}")]
        [Route("~/api/policy/store-policy-detail/page/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Policy.StorePolicyDetail> GetPagedResult(long pageNumber)
        {
            try
            {
                return this.StorePolicyDetailContext.GetPagedResult(pageNumber);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Creates a filtered and paginated collection containing 25 store policy details on each page, sorted by the property StorePolicyDetailId.
        /// </summary>
        /// <param name="pageNumber">Enter the page number to produce the resultset.</param>
        /// <param name="filters">The list of filter conditions.</param>
        /// <returns>Returns the requested page from the collection using the supplied filters.</returns>
        [AcceptVerbs("POST")]
        [Route("get-where/{pageNumber}")]
        [Route("~/api/policy/store-policy-detail/get-where/{pageNumber}")]
        public IEnumerable<MixERP.Net.Entities.Policy.StorePolicyDetail> GetWhere(long pageNumber, [FromBody]dynamic filters)
        {
            try
            {
                List<EntityParser.Filter> f = JsonConvert.DeserializeObject<List<EntityParser.Filter>>(filters);
                return this.StorePolicyDetailContext.GetWhere(pageNumber, f);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Displayfield is a lightweight key/value collection of store policy details.
        /// </summary>
        /// <returns>Returns an enumerable key/value collection of store policy details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("display-fields")]
        [Route("~/api/policy/store-policy-detail/display-fields")]
        public IEnumerable<DisplayField> GetDisplayFields()
        {
            try
            {
                return this.StorePolicyDetailContext.GetDisplayFields();
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     A custom field is a user defined field for store policy details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of store policy details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/policy/store-policy-detail/custom-fields")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields()
        {
            try
            {
                return this.StorePolicyDetailContext.GetCustomFields(null);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     A custom field is a user defined field for store policy details.
        /// </summary>
        /// <returns>Returns an enumerable custom field collection of store policy details.</returns>
        [AcceptVerbs("GET", "HEAD")]
        [Route("custom-fields")]
        [Route("~/api/policy/store-policy-detail/custom-fields/{resourceId}")]
        public IEnumerable<PetaPoco.CustomField> GetCustomFields(string resourceId)
        {
            try
            {
                return this.StorePolicyDetailContext.GetCustomFields(resourceId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds or edits your instance of StorePolicyDetail class.
        /// </summary>
        /// <param name="storePolicyDetail">Your instance of store policy details class to add or edit.</param>
        [AcceptVerbs("PUT")]
        [Route("add-or-edit")]
        [Route("~/api/policy/store-policy-detail/add-or-edit")]
        public void AddOrEdit([FromBody]MixERP.Net.Entities.Policy.StorePolicyDetail storePolicyDetail)
        {
            if (storePolicyDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.StorePolicyDetailContext.AddOrEdit(storePolicyDetail);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Adds your instance of StorePolicyDetail class.
        /// </summary>
        /// <param name="storePolicyDetail">Your instance of store policy details class to add.</param>
        [AcceptVerbs("POST")]
        [Route("add/{storePolicyDetail}")]
        [Route("~/api/policy/store-policy-detail/add/{storePolicyDetail}")]
        public void Add(MixERP.Net.Entities.Policy.StorePolicyDetail storePolicyDetail)
        {
            if (storePolicyDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.StorePolicyDetailContext.Add(storePolicyDetail);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Edits existing record with your instance of StorePolicyDetail class.
        /// </summary>
        /// <param name="storePolicyDetail">Your instance of StorePolicyDetail class to edit.</param>
        /// <param name="storePolicyDetailId">Enter the value for StorePolicyDetailId in order to find and edit the existing record.</param>
        [AcceptVerbs("PUT")]
        [Route("edit/{storePolicyDetailId}")]
        [Route("~/api/policy/store-policy-detail/edit/{storePolicyDetailId}")]
        public void Edit(long storePolicyDetailId, [FromBody] MixERP.Net.Entities.Policy.StorePolicyDetail storePolicyDetail)
        {
            if (storePolicyDetail == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.MethodNotAllowed));
            }

            try
            {
                this.StorePolicyDetailContext.Update(storePolicyDetail, storePolicyDetailId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }

        /// <summary>
        ///     Deletes an existing instance of StorePolicyDetail class via StorePolicyDetailId.
        /// </summary>
        /// <param name="storePolicyDetailId">Enter the value for StorePolicyDetailId in order to find and delete the existing record.</param>
        [AcceptVerbs("DELETE")]
        [Route("delete/{storePolicyDetailId}")]
        [Route("~/api/policy/store-policy-detail/delete/{storePolicyDetailId}")]
        public void Delete(long storePolicyDetailId)
        {
            try
            {
                this.StorePolicyDetailContext.Delete(storePolicyDetailId);
            }
            catch (UnauthorizedException)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Forbidden));
            }
            catch
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }
        }


    }
}