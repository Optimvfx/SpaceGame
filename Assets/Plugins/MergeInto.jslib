mergeInto(LibraryManager.library, {

Print: function (str) {
    window.alert(UTF8ToString(str));
  },

  SaveToLocalStorage : function(key, data) {
    localStorage.setItem(Pointer_stringify(key), Pointer_stringify(data));
  },

    LoadFromLocalStorage : function(key) {
    try
    {
      var returnStr = "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjYyNyIsInJvbGUiOiJVc2VyIiwibmJmIjoxNjY5MTkyNjkxLCJleHAiOjE2Njk3OTc0OTEsImlzcyI6ImxvY2FsaG9zdCIsImF1ZCI6ImxvY2FsaG9zdCJ9.O1h8uTI0fPTOGgrTHaGFc1y-U1Au6hnocOYgWeFZZYY";
      var bufferSize = lengthBytesUTF8(returnStr) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(returnStr, buffer, bufferSize);
      return buffer;
     }
     catch
     {
      return "";
     }
  },

  RemoveFromLocalStorage : function(key) {
    localStorage.removeItem(Pointer_stringify(key));
  },

  HasKeyInLocalStorage : function(key) {
     if (localStorage.getItem(Pointer_stringify(key))) {
      return 1;
    }
    else {
      return 0;
    }
  },

});

