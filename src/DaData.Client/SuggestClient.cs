﻿using System;
using System.Net;
using RestSharp;

namespace DaData.Client {

    public class SuggestClient {
        const string SUGGESTIONS_URL = "{0}/suggest";
        const string ADDRESS_RESOURCE = "address";
        const string PARTY_RESOURCE = "party";
        const string BANK_RESOURCE = "bank";
        const string FIO_RESOURCE = "fio";
        const string EMAIL_RESOURCE = "email";

        RestClient _client;
        string _token;
        ContentType _contentType = ContentType.JSON;

        public IWebProxy Proxy {
            get { return _client.Proxy; }
            set { _client.Proxy = value; }
        }       

        public SuggestClient(string token, string baseUrl) {
            _token = token;
            _client = new RestClient (String.Format (SUGGESTIONS_URL, baseUrl));
        }

        public SuggestAddressResponse QueryAddress(string address) {
            return QueryAddress(new AddressSuggestQuery(address));
        }

        public SuggestAddressResponse QueryAddress(AddressSuggestQuery query) {
            var request = new RestRequest(ADDRESS_RESOURCE, Method.POST);
            return Execute<SuggestAddressResponse>(request, query);
        }

        public SuggestBankResponse QueryBank(string bank) {
            return QueryBank(new BankSuggestQuery(bank));
        }

        public SuggestBankResponse QueryBank(BankSuggestQuery query) {
            var request = new RestRequest(BANK_RESOURCE, Method.POST);
            return Execute<SuggestBankResponse>(request, query);
        }

        public SuggestEmailResponse QueryEmail(string email) {
            var request = new RestRequest(EMAIL_RESOURCE, Method.POST);
            var query = new SuggestQuery(email);
            return Execute<SuggestEmailResponse>(request, query);
        }

        public SuggestFioResponse QueryFio(string fio) {
            return QueryFio(new FioSuggestQuery(fio));
        }

        public SuggestFioResponse QueryFio(FioSuggestQuery query) {
            var request = new RestRequest(FIO_RESOURCE, Method.POST);
            return Execute<SuggestFioResponse>(request, query);
        }

        public SuggestPartyResponse QueryParty(string party) {
            return QueryParty(new PartySuggestQuery(party));
        }

        public SuggestPartyResponse QueryParty(PartySuggestQuery query) {
            var request = new RestRequest(PARTY_RESOURCE, Method.POST);
            return Execute<SuggestPartyResponse>(request, query);
        }

        private T Execute<T>(RestRequest request, SuggestQuery query) where T : new() {
            request.AddHeader("Authorization", "Token " + this._token);
            request.AddHeader("Content-Type", _contentType.Name);
            request.AddHeader("Accept", _contentType.Name);
            request.RequestFormat = _contentType.Format;
            request.XmlSerializer.ContentType = _contentType.Name;
            request.AddBody(query);
            var response = _client.Execute<T>(request);

            if (response.ErrorException != null) {
                throw response.ErrorException;
            }
            return response.Data;
        }
    }
}