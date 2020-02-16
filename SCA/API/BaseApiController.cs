using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SCA.API {
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	public class BaseApiController : ApiController {
	}
}