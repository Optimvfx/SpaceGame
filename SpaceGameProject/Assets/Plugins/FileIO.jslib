mergeInto(LibraryManager.library, {

  SaveToLocalStorage : function(key, data) {
    localStorage.setItem(key, data);
  },

  LoadFromLocalStorage : function(key) {
      try
      {
      var returnStr = localStorage.getItem(key);
      return returnStr;
      }
      catch
      {
          return "";
      }
  },

  RemoveFromLocalStorage : function(key) {
    localStorage.removeItem(key);
  },

  HasKeyInLocalStorage : function(key) {
    if (localStorage.getItem(key)) {
      return 1;
    }
    else {
      return 0;
    }
  }
});
