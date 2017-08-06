using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Mosfin.Clients.Common.Contracts.Utils;

namespace Mosfin.BackendEnine.Service.Utils
{
    public class MosfinRestClient:IDisposable
    {
        public MosfinRestClient()
        {
        }

		public async Task<T> GetJSON<T>(string path,
												 object queryParams = null,
												  object headers = null, object cookies = null)
		{

			try
			{
				return await new Url(path)
					.SetQueryParams(queryParams ?? new { }).WithCookies(cookies ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
							   .WithHeaders(headers ?? new { })
					.GetAsync().ReceiveJson<T>();
			}
			catch (TaskCanceledException ex)
			{
				return default(T);
			}
		}

		public async Task<string> GetString(string path,
												 object queryParams = null,
												  object headers = null, object cookies = null)
		{
			try
			{
				return await new Url(path)
					.SetQueryParams(queryParams ?? new { }).WithCookies(cookies ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
					.WithHeaders(headers ?? new { }).GetStringAsync();
			}
			catch (TaskCanceledException ex)
			{
				return string.Empty;
			}
			catch (IOException)
			{
				return string.Empty;
			}
		}

		public async Task<T> PostJSON<T>(string path, object payload = null, int timeout = Configs.REST_REQUEST_TIMEOUT, object headers = null,
												  object cookies = null)
		{
			try
			{
				var result = await new Url(path)
					.WithTimeout(timeout)
					.WithCookies(cookies ?? new { })
								   .WithHeaders(headers ?? new { })
									.PostJsonAsync(payload ?? new object()).ReceiveJson<T>();
				return result;
			}
			catch (TaskCanceledException ex)
			{
				return default(T);
			}
			catch (IOException)
			{
				return default(T);
			}
		}

		public async Task<string> PostJSONForString(string path, object payload = null, object headers = null,
												  object cookies = null)
		{
			try
			{
				var result = await new Url(path)
					.WithTimeout(Configs.REST_REQUEST_TIMEOUT)
					.WithCookies(cookies ?? new { })
								   .WithHeaders(headers ?? new { })
					.PostJsonAsync(payload ?? new object()).ReceiveString();
				return result;
			}
			catch (TaskCanceledException ex)
			{
				return string.Empty;
			}
			catch (IOException)
			{
				return string.Empty;
			}
		}


		public async Task PostJSONAsync(string path, object payload = null, object headers = null,
												  object cookies = null)
		{
			try
			{
				await new Url(path).WithCookies(cookies ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
								  .WithHeaders(headers ?? new { })
								   .PostJsonAsync(payload ?? new object());
			}
			catch (TaskCanceledException ex)
			{

			}
			catch (IOException)
			{

			}
		}


		public async Task<String> UploadByteArrayAsync(string path, byte[] imageBytes, byte[] secondaryImageBytes,
													   string token, ICollection<KeyValuePair<String, String>>
													   payload = null, string fileIdentity = null,
													   string secondaryFileIdentity = null)
		{
			try
			{
				using (Stream primaryFileStream = new MemoryStream(imageBytes))
				{
					using (Stream secondaryFileStream = secondaryImageBytes == null ? new MemoryStream() : new MemoryStream(secondaryImageBytes))
						return await new Url(path).WithTimeout(Configs.REST_REQUEST_TIMEOUT).PostMultipartAsync((mp) =>
					   {
						   mp.AddFile(fileIdentity ?? "File", primaryFileStream, "my_uploaded_image.jpg");
						   if (secondaryImageBytes != null)
						   {
							   mp.AddFile(secondaryFileIdentity ?? "BackFile", secondaryFileStream, "my_secondary_uploaded_image.jpg");
						   }
						   if (payload != null)
						   {
							   foreach (var item in payload)
							   {
								   if (item.Value != null) mp.AddString(item.Key, item.Value);
							   }
						   }
					   }).ReceiveJson<String>();
				}
			}
			catch (TaskCanceledException ex)
			{
				return string.Empty;
			}
			catch (IOException)
			{
				return string.Empty;
			}
		}

		public async Task<T> PostUrlEncodedAsync<T>(string path, object payload = null, object headers = null,
												  object cookies = null)
		{
			try
			{
				return await new Url(path).WithCookies(cookies ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
								   .WithHeaders(headers ?? new { })
										  .PostUrlEncodedAsync(payload ?? new object()).ReceiveJson<T>();
			}
			catch (TaskCanceledException ex)
			{
				return default(T);
			}
			catch (IOException)
			{
				return default(T);
			}
		}

		public async Task PostUrlEncodedAsync(string path, object payload = null, object headers = null,
												  object cookies = null)
		{
			try
			{
				await new Url(path).WithCookies(cookies ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
								  .WithHeaders(headers ?? new { })
								   .PostUrlEncodedAsync(payload ?? new object());
			}
			catch (TaskCanceledException ex)
			{

			}
			catch (IOException)
			{

			}
		}
		public async Task<T> PutJSONAsync<T>(string path, object payload = null, object headers = null,
												  object cookies = null)
		{
			try
			{
				return await new Url(path).WithCookies(cookies ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
								   .WithHeaders(headers ?? new { })
										  .PutJsonAsync(payload ?? new object()).ReceiveJson<T>();
			}
			catch (TaskCanceledException ex)
			{
				return default(T);
			}
		}

		public async Task PutJSONAsync(string path, object payload = null, object headers = null,
												  object cookies = null)
		{
			try
			{
				await new Url(path).WithCookies(cookies ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
								  .WithHeaders(headers ?? new { })
								   .PutJsonAsync(payload ?? new object());
			}
			catch (TaskCanceledException ex)
			{

			}
			catch (IOException)
			{

			}
		}


		public async Task<T> DeleteAsync<T>(string path,
							   object queryParams = null, object headers = null,
							  object cookies = null)
		{
			try
			{
				return await new Url(path)
						 .SetQueryParams(queryParams ?? new { })
					.WithCookies(cookies ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
								   .WithHeaders(headers ?? new { })
					.DeleteAsync().ReceiveJson<T>();
			}
			catch (TaskCanceledException ex)
			{
				return default(T);
			}
			catch (IOException)
			{
				return default(T);
			}
		}


		public async Task DeleteAsync(string path,
							   object queryParams = null, object headers = null,
							  object cookies = null)
		{
			try
			{
				await new Url(path)
				   .SetQueryParams(queryParams ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
				   .WithCookies(cookies ?? new { })
								  .WithHeaders(headers ?? new { })
										 .DeleteAsync();
			}
			catch (TaskCanceledException ex)
			{

			}
			catch (IOException)
			{

			}
		}


		public async Task<byte[]> GetBytesAsync(string path,
							   object queryParams = null, object headers = null,
							  object cookies = null)
		{
			try
			{
				return await new Url(path)
				   .SetQueryParams(queryParams ?? new { }).WithTimeout(Configs.REST_REQUEST_TIMEOUT)
				   .WithCookies(cookies ?? new { })
					.WithHeaders(headers ?? new { })
					.GetBytesAsync();
			}
			catch (TaskCanceledException ex)
			{
				return default(byte[]);
			}
			catch (IOException)
			{
				return default(byte[]);
			}
		}

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
