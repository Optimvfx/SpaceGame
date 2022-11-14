mergeInto(LibraryManager.library, {

  SaveToLocalStorage : function(key, data) {
    window.localStorage.setItem(key, data);
  },

  LoadFromLocalStorage : function(key) {
      try
      {
      var returnStr = window.localStorage.getItem(key);
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
    window.localStorage.removeItem(key);
  },

  HasKeyInLocalStorage : function(key) {
    if (window.localStorage.getItem(key)) {
      return 1;
    }
    else {
      return 0;
    }
  }
});
