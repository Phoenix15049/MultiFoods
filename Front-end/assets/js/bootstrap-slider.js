/*! =========================================================
 * bootstrap-slider.js
 *
 * Maintainers:
 *		Kyle Kemp
 *			- Twitter: @seiyria
 *			- Github:  seiyria
 *		Rohit Kalkur
 *			- Twitter: @Rovolutionary
 *			- Github:  rovolution
 *
 * =========================================================
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ========================================================= */

/**
 * Bridget makes jQuery widgets
 * v1.0.1
 * MIT license
 */

!(function (t, i) {
  if ("function" == typeof define && define.amd) define(["jquery"], i);
  else if ("object" == typeof module && module.exports) {
    var e;
    try {
      e = require("jquery");
    } catch (s) {
      e = null;
    }
    module.exports = i(e);
  } else t.Slider = i(t.jQuery);
})(this, function (t) {
  var i;
  return (
    (function (t) {
      "use strict";
      function i() {}
      function e(t) {
        function e(i) {
          i.prototype.option ||
            (i.prototype.option = function (i) {
              t.isPlainObject(i) &&
                (this.options = t.extend(!0, this.options, i));
            });
        }
        function o(i, e) {
          t.fn[i] = function (o) {
            if ("string" == typeof o) {
              for (
                var a = s.call(arguments, 1), h = 0, l = this.length;
                l > h;
                h++
              ) {
                var r = this[h],
                  p = t.data(r, i);
                if (p)
                  if (t.isFunction(p[o]) && "_" !== o.charAt(0)) {
                    var d = p[o].apply(p, a);
                    if (void 0 !== d && d !== p) return d;
                  } else n("no such method '" + o + "' for " + i + " instance");
                else
                  n(
                    "cannot call methods on " +
                      i +
                      " prior to initialization; attempted to call '" +
                      o +
                      "'"
                  );
              }
              return this;
            }
            var c = this.map(function () {
              var s = t.data(this, i);
              return (
                s
                  ? (s.option(o), s._init())
                  : ((s = new e(this, o)), t.data(this, i, s)),
                t(this)
              );
            });
            return !c || c.length > 1 ? c : c[0];
          };
        }
        if (t) {
          var n =
            "undefined" == typeof console
              ? i
              : function (t) {
                  console.error(t);
                };
          return (
            (t.bridget = function (t, i) {
              e(i), o(t, i);
            }),
            t.bridget
          );
        }
      }
      var s = Array.prototype.slice;
      e(t);
    })(t),
    (function (t) {
      function e(i, e) {
        function s(t, i) {
          var e = "data-slider-" + i.replace(/_/g, "-"),
            s = t.getAttribute(e);
          try {
            return JSON.parse(s);
          } catch (o) {
            return s;
          }
        }
        (this._state = {
          value: null,
          enabled: null,
          offset: null,
          size: null,
          percentage: null,
          inDrag: !1,
          over: !1,
        }),
          "string" == typeof i
            ? (this.element = document.querySelector(i))
            : i instanceof HTMLElement && (this.element = i),
          (e = e ? e : {});
        for (
          var n = Object.keys(this.defaultOptions), a = 0;
          a < n.length;
          a++
        ) {
          var h = n[a],
            l = e[h];
          (l = "undefined" != typeof l ? l : s(this.element, h)),
            (l = null !== l ? l : this.defaultOptions[h]),
            this.options || (this.options = {}),
            (this.options[h] = l);
        }
        "vertical" !== this.options.orientation ||
        ("top" !== this.options.tooltip_position &&
          "bottom" !== this.options.tooltip_position)
          ? "horizontal" !== this.options.orientation ||
            ("left" !== this.options.tooltip_position &&
              "right" !== this.options.tooltip_position) ||
            (this.options.tooltip_position = "top")
          : (this.options.tooltip_position = "right");
        var r,
          p,
          d,
          c,
          u,
          m = this.element.style.width,
          _ = !1,
          v = this.element.parentNode;
        if (this.sliderElem) _ = !0;
        else {
          (this.sliderElem = document.createElement("div")),
            (this.sliderElem.className = "slider");
          var f = document.createElement("div");
          (f.className = "slider-track"),
            (p = document.createElement("div")),
            (p.className = "slider-track-low"),
            (r = document.createElement("div")),
            (r.className = "slider-selection"),
            (d = document.createElement("div")),
            (d.className = "slider-track-high"),
            (c = document.createElement("div")),
            (c.className = "slider-handle min-slider-handle"),
            c.setAttribute("role", "slider"),
            c.setAttribute("aria-valuemin", this.options.min),
            c.setAttribute("aria-valuemax", this.options.max),
            (u = document.createElement("div")),
            (u.className = "slider-handle max-slider-handle"),
            u.setAttribute("role", "slider"),
            u.setAttribute("aria-valuemin", this.options.min),
            u.setAttribute("aria-valuemax", this.options.max),
            f.appendChild(p),
            f.appendChild(r),
            f.appendChild(d);
          var g = Array.isArray(this.options.labelledby);
          if (
            (g &&
              this.options.labelledby[0] &&
              c.setAttribute("aria-labelledby", this.options.labelledby[0]),
            g &&
              this.options.labelledby[1] &&
              u.setAttribute("aria-labelledby", this.options.labelledby[1]),
            !g &&
              this.options.labelledby &&
              (c.setAttribute("aria-labelledby", this.options.labelledby),
              u.setAttribute("aria-labelledby", this.options.labelledby)),
            (this.ticks = []),
            Array.isArray(this.options.ticks) && this.options.ticks.length > 0)
          ) {
            for (a = 0; a < this.options.ticks.length; a++) {
              var y = document.createElement("div");
              (y.className = "slider-tick"),
                this.ticks.push(y),
                f.appendChild(y);
            }
            r.className += " tick-slider-selection";
          }
          if (
            (f.appendChild(c),
            f.appendChild(u),
            (this.tickLabels = []),
            Array.isArray(this.options.ticks_labels) &&
              this.options.ticks_labels.length > 0)
          )
            for (
              this.tickLabelContainer = document.createElement("div"),
                this.tickLabelContainer.className =
                  "slider-tick-label-container",
                a = 0;
              a < this.options.ticks_labels.length;
              a++
            ) {
              var b = document.createElement("div"),
                k = 0 === this.options.ticks_positions.length,
                E =
                  this.options.reversed && k
                    ? this.options.ticks_labels.length - (a + 1)
                    : a;
              (b.className = "slider-tick-label"),
                (b.innerHTML = this.options.ticks_labels[E]),
                this.tickLabels.push(b),
                this.tickLabelContainer.appendChild(b);
            }
          var x = function (t) {
              var i = document.createElement("div");
              i.className = "tooltip-arrow";
              var e = document.createElement("div");
              (e.className = "tooltip-inner"),
                t.appendChild(i),
                t.appendChild(e);
            },
            C = document.createElement("div");
          (C.className = "tooltip tooltip-main"),
            C.setAttribute("role", "presentation"),
            x(C);
          var w = document.createElement("div");
          (w.className = "tooltip tooltip-min"),
            w.setAttribute("role", "presentation"),
            x(w);
          var L = document.createElement("div");
          (L.className = "tooltip tooltip-max"),
            L.setAttribute("role", "presentation"),
            x(L),
            this.sliderElem.appendChild(f),
            this.sliderElem.appendChild(C),
            this.sliderElem.appendChild(w),
            this.sliderElem.appendChild(L),
            this.tickLabelContainer &&
              this.sliderElem.appendChild(this.tickLabelContainer),
            v.insertBefore(this.sliderElem, this.element),
            (this.element.style.display = "none");
        }
        if (
          (t &&
            ((this.$element = t(this.element)),
            (this.$sliderElem = t(this.sliderElem))),
          (this.eventToCallbackMap = {}),
          (this.sliderElem.id = this.options.id),
          (this.touchCapable =
            "ontouchstart" in window ||
            (window.DocumentTouch && document instanceof window.DocumentTouch)),
          (this.tooltip = this.sliderElem.querySelector(".tooltip-main")),
          (this.tooltipInner = this.tooltip.querySelector(".tooltip-inner")),
          (this.tooltip_min = this.sliderElem.querySelector(".tooltip-min")),
          (this.tooltipInner_min =
            this.tooltip_min.querySelector(".tooltip-inner")),
          (this.tooltip_max = this.sliderElem.querySelector(".tooltip-max")),
          (this.tooltipInner_max =
            this.tooltip_max.querySelector(".tooltip-inner")),
          o[this.options.scale] && (this.options.scale = o[this.options.scale]),
          _ === !0 &&
            (this._removeClass(this.sliderElem, "slider-horizontal"),
            this._removeClass(this.sliderElem, "slider-vertical"),
            this._removeClass(this.tooltip, "hide"),
            this._removeClass(this.tooltip_min, "hide"),
            this._removeClass(this.tooltip_max, "hide"),
            ["left", "top", "width", "height"].forEach(function (t) {
              this._removeProperty(this.trackLow, t),
                this._removeProperty(this.trackSelection, t),
                this._removeProperty(this.trackHigh, t);
            }, this),
            [this.handle1, this.handle2].forEach(function (t) {
              this._removeProperty(t, "left"), this._removeProperty(t, "top");
            }, this),
            [this.tooltip, this.tooltip_min, this.tooltip_max].forEach(
              function (t) {
                this._removeProperty(t, "left"),
                  this._removeProperty(t, "top"),
                  this._removeProperty(t, "margin-left"),
                  this._removeProperty(t, "margin-top"),
                  this._removeClass(t, "right"),
                  this._removeClass(t, "top");
              },
              this
            )),
          "vertical" === this.options.orientation
            ? (this._addClass(this.sliderElem, "slider-vertical"),
              (this.stylePos = "top"),
              (this.mousePos = "pageY"),
              (this.sizePos = "offsetHeight"))
            : (this._addClass(this.sliderElem, "slider-horizontal"),
              (this.sliderElem.style.width = m),
              (this.options.orientation = "horizontal"),
              (this.stylePos = "left"),
              (this.mousePos = "pageX"),
              (this.sizePos = "offsetWidth")),
          this._setTooltipPosition(),
          Array.isArray(this.options.ticks) &&
            this.options.ticks.length > 0 &&
            ((this.options.max = Math.max.apply(Math, this.options.ticks)),
            (this.options.min = Math.min.apply(Math, this.options.ticks))),
          Array.isArray(this.options.value)
            ? ((this.options.range = !0),
              (this._state.value = this.options.value))
            : this.options.range
            ? (this._state.value = [this.options.value, this.options.max])
            : (this._state.value = this.options.value),
          (this.trackLow = p || this.trackLow),
          (this.trackSelection = r || this.trackSelection),
          (this.trackHigh = d || this.trackHigh),
          "none" === this.options.selection &&
            (this._addClass(this.trackLow, "hide"),
            this._addClass(this.trackSelection, "hide"),
            this._addClass(this.trackHigh, "hide")),
          (this.handle1 = c || this.handle1),
          (this.handle2 = u || this.handle2),
          _ === !0)
        )
          for (
            this._removeClass(this.handle1, "round triangle"),
              this._removeClass(this.handle2, "round triangle hide"),
              a = 0;
            a < this.ticks.length;
            a++
          )
            this._removeClass(this.ticks[a], "round triangle hide");
        var P = ["round", "triangle", "custom"],
          T = -1 !== P.indexOf(this.options.handle);
        if (T)
          for (
            this._addClass(this.handle1, this.options.handle),
              this._addClass(this.handle2, this.options.handle),
              a = 0;
            a < this.ticks.length;
            a++
          )
            this._addClass(this.ticks[a], this.options.handle);
        (this._state.offset = this._offset(this.sliderElem)),
          (this._state.size = this.sliderElem[this.sizePos]),
          this.setValue(this._state.value),
          (this.handle1Keydown = this._keydown.bind(this, 0)),
          this.handle1.addEventListener("keydown", this.handle1Keydown, !1),
          (this.handle2Keydown = this._keydown.bind(this, 1)),
          this.handle2.addEventListener("keydown", this.handle2Keydown, !1),
          (this.mousedown = this._mousedown.bind(this)),
          this.touchCapable &&
            this.sliderElem.addEventListener("touchstart", this.mousedown, !1),
          this.sliderElem.addEventListener("mousedown", this.mousedown, !1),
          "hide" === this.options.tooltip
            ? (this._addClass(this.tooltip, "hide"),
              this._addClass(this.tooltip_min, "hide"),
              this._addClass(this.tooltip_max, "hide"))
            : "always" === this.options.tooltip
            ? (this._showTooltip(), (this._alwaysShowTooltip = !0))
            : ((this.showTooltip = this._showTooltip.bind(this)),
              (this.hideTooltip = this._hideTooltip.bind(this)),
              this.sliderElem.addEventListener(
                "mouseenter",
                this.showTooltip,
                !1
              ),
              this.sliderElem.addEventListener(
                "mouseleave",
                this.hideTooltip,
                !1
              ),
              this.handle1.addEventListener("focus", this.showTooltip, !1),
              this.handle1.addEventListener("blur", this.hideTooltip, !1),
              this.handle2.addEventListener("focus", this.showTooltip, !1),
              this.handle2.addEventListener("blur", this.hideTooltip, !1)),
          this.options.enabled ? this.enable() : this.disable();
      }
      var s = {
          formatInvalidInputErrorMsg: function (t) {
            return "Invalid input value '" + t + "' passed in";
          },
          callingContextNotSliderInstance:
            "Calling context element does not have instance of Slider bound to it. Check your code to make sure the JQuery object returned from the call to the slider() initializer is calling the method",
        },
        o = {
          linear: {
            toValue: function (t) {
              var i = (t / 100) * (this.options.max - this.options.min),
                e = !0;
              if (this.options.ticks_positions.length > 0) {
                for (
                  var s, o, n, a = 0, h = 1;
                  h < this.options.ticks_positions.length;
                  h++
                )
                  if (t <= this.options.ticks_positions[h]) {
                    (s = this.options.ticks[h - 1]),
                      (n = this.options.ticks_positions[h - 1]),
                      (o = this.options.ticks[h]),
                      (a = this.options.ticks_positions[h]);
                    break;
                  }
                var l = (t - n) / (a - n);
                (i = s + l * (o - s)), (e = !1);
              }
              var r = e ? this.options.min : 0,
                p = r + Math.round(i / this.options.step) * this.options.step;
              return p < this.options.min
                ? this.options.min
                : p > this.options.max
                ? this.options.max
                : p;
            },
            toPercentage: function (t) {
              if (this.options.max === this.options.min) return 0;
              if (this.options.ticks_positions.length > 0) {
                for (
                  var i, e, s, o = 0, n = 0;
                  n < this.options.ticks.length;
                  n++
                )
                  if (t <= this.options.ticks[n]) {
                    (i = n > 0 ? this.options.ticks[n - 1] : 0),
                      (s = n > 0 ? this.options.ticks_positions[n - 1] : 0),
                      (e = this.options.ticks[n]),
                      (o = this.options.ticks_positions[n]);
                    break;
                  }
                if (n > 0) {
                  var a = (t - i) / (e - i);
                  return s + a * (o - s);
                }
              }
              return (
                (100 * (t - this.options.min)) /
                (this.options.max - this.options.min)
              );
            },
          },
          logarithmic: {
            toValue: function (t) {
              var i = 0 === this.options.min ? 0 : Math.log(this.options.min),
                e = Math.log(this.options.max),
                s = Math.exp(i + ((e - i) * t) / 100);
              return (
                (s =
                  this.options.min +
                  Math.round((s - this.options.min) / this.options.step) *
                    this.options.step),
                s < this.options.min
                  ? this.options.min
                  : s > this.options.max
                  ? this.options.max
                  : s
              );
            },
            toPercentage: function (t) {
              if (this.options.max === this.options.min) return 0;
              var i = Math.log(this.options.max),
                e = 0 === this.options.min ? 0 : Math.log(this.options.min),
                s = 0 === t ? 0 : Math.log(t);
              return (100 * (s - e)) / (i - e);
            },
          },
        };
      if (
        ((i = function (t, i) {
          return e.call(this, t, i), this;
        }),
        (i.prototype = {
          _init: function () {},
          constructor: i,
          defaultOptions: {
            id: "",
            min: 0,
            max: 10,
            step: 1,
            precision: 0,
            orientation: "horizontal",
            value: 5,
            range: !1,
            selection: "before",
            tooltip: "show",
            tooltip_split: !1,
            handle: "round",
            reversed: !1,
            enabled: !0,
            formatter: function (t) {
              return Array.isArray(t) ? t[0] + " : " + t[1] : t;
            },
            natural_arrow_keys: !1,
            ticks: [],
            ticks_positions: [],
            ticks_labels: [],
            ticks_snap_bounds: 0,
            scale: "linear",
            focus: !1,
            tooltip_position: null,
            labelledby: null,
          },
          getElement: function () {
            return this.sliderElem;
          },
          getValue: function () {
            return this.options.range
              ? this._state.value
              : this._state.value[0];
          },
          setValue: function (t, i, e) {
            t || (t = 0);
            var s = this.getValue();
            this._state.value = this._validateInputValue(t);
            var o = this._applyPrecision.bind(this);
            this.options.range
              ? ((this._state.value[0] = o(this._state.value[0])),
                (this._state.value[1] = o(this._state.value[1])),
                (this._state.value[0] = Math.max(
                  this.options.min,
                  Math.min(this.options.max, this._state.value[0])
                )),
                (this._state.value[1] = Math.max(
                  this.options.min,
                  Math.min(this.options.max, this._state.value[1])
                )))
              : ((this._state.value = o(this._state.value)),
                (this._state.value = [
                  Math.max(
                    this.options.min,
                    Math.min(this.options.max, this._state.value)
                  ),
                ]),
                this._addClass(this.handle2, "hide"),
                "after" === this.options.selection
                  ? (this._state.value[1] = this.options.max)
                  : (this._state.value[1] = this.options.min)),
              this.options.max > this.options.min
                ? (this._state.percentage = [
                    this._toPercentage(this._state.value[0]),
                    this._toPercentage(this._state.value[1]),
                    (100 * this.options.step) /
                      (this.options.max - this.options.min),
                  ])
                : (this._state.percentage = [0, 0, 100]),
              this._layout();
            var n = this.options.range
              ? this._state.value
              : this._state.value[0];
            return (
              i === !0 && this._trigger("slide", n),
              s !== n &&
                e === !0 &&
                this._trigger("change", { oldValue: s, newValue: n }),
              this._setDataVal(n),
              this
            );
          },
          destroy: function () {
            this._removeSliderEventHandlers(),
              this.sliderElem.parentNode.removeChild(this.sliderElem),
              (this.element.style.display = ""),
              this._cleanUpEventCallbacksMap(),
              this.element.removeAttribute("data"),
              t &&
                (this._unbindJQueryEventHandlers(),
                this.$element.removeData("slider"));
          },
          disable: function () {
            return (
              (this._state.enabled = !1),
              this.handle1.removeAttribute("tabindex"),
              this.handle2.removeAttribute("tabindex"),
              this._addClass(this.sliderElem, "slider-disabled"),
              this._trigger("slideDisabled"),
              this
            );
          },
          enable: function () {
            return (
              (this._state.enabled = !0),
              this.handle1.setAttribute("tabindex", 0),
              this.handle2.setAttribute("tabindex", 0),
              this._removeClass(this.sliderElem, "slider-disabled"),
              this._trigger("slideEnabled"),
              this
            );
          },
          toggle: function () {
            return this._state.enabled ? this.disable() : this.enable(), this;
          },
          isEnabled: function () {
            return this._state.enabled;
          },
          on: function (t, i) {
            return this._bindNonQueryEventHandler(t, i), this;
          },
          off: function (i, e) {
            t
              ? (this.$element.off(i, e), this.$sliderElem.off(i, e))
              : this._unbindNonQueryEventHandler(i, e);
          },
          getAttribute: function (t) {
            return t ? this.options[t] : this.options;
          },
          setAttribute: function (t, i) {
            return (this.options[t] = i), this;
          },
          refresh: function () {
            return (
              this._removeSliderEventHandlers(),
              e.call(this, this.element, this.options),
              t && t.data(this.element, "slider", this),
              this
            );
          },
          relayout: function () {
            return this._layout(), this;
          },
          _removeSliderEventHandlers: function () {
            this.handle1.removeEventListener(
              "keydown",
              this.handle1Keydown,
              !1
            ),
              this.handle2.removeEventListener(
                "keydown",
                this.handle2Keydown,
                !1
              ),
              this.showTooltip &&
                (this.handle1.removeEventListener(
                  "focus",
                  this.showTooltip,
                  !1
                ),
                this.handle2.removeEventListener(
                  "focus",
                  this.showTooltip,
                  !1
                )),
              this.hideTooltip &&
                (this.handle1.removeEventListener("blur", this.hideTooltip, !1),
                this.handle2.removeEventListener("blur", this.hideTooltip, !1)),
              this.showTooltip &&
                this.sliderElem.removeEventListener(
                  "mouseenter",
                  this.showTooltip,
                  !1
                ),
              this.hideTooltip &&
                this.sliderElem.removeEventListener(
                  "mouseleave",
                  this.hideTooltip,
                  !1
                ),
              this.sliderElem.removeEventListener(
                "touchstart",
                this.mousedown,
                !1
              ),
              this.sliderElem.removeEventListener(
                "mousedown",
                this.mousedown,
                !1
              );
          },
          _bindNonQueryEventHandler: function (t, i) {
            void 0 === this.eventToCallbackMap[t] &&
              (this.eventToCallbackMap[t] = []),
              this.eventToCallbackMap[t].push(i);
          },
          _unbindNonQueryEventHandler: function (t, i) {
            var e = this.eventToCallbackMap[t];
            if (void 0 !== e)
              for (var s = 0; s < e.length; s++)
                if (e[s] === i) {
                  e.splice(s, 1);
                  break;
                }
          },
          _cleanUpEventCallbacksMap: function () {
            for (
              var t = Object.keys(this.eventToCallbackMap), i = 0;
              i < t.length;
              i++
            ) {
              var e = t[i];
              this.eventToCallbackMap[e] = null;
            }
          },
          _showTooltip: function () {
            this.options.tooltip_split === !1
              ? (this._addClass(this.tooltip, "in"),
                (this.tooltip_min.style.display = "none"),
                (this.tooltip_max.style.display = "none"))
              : (this._addClass(this.tooltip_min, "in"),
                this._addClass(this.tooltip_max, "in"),
                (this.tooltip.style.display = "none")),
              (this._state.over = !0);
          },
          _hideTooltip: function () {
            this._state.inDrag === !1 &&
              this.alwaysShowTooltip !== !0 &&
              (this._removeClass(this.tooltip, "in"),
              this._removeClass(this.tooltip_min, "in"),
              this._removeClass(this.tooltip_max, "in")),
              (this._state.over = !1);
          },
          _layout: function () {
            var t;
            if (
              ((t = this.options.reversed
                ? [
                    100 - this._state.percentage[0],
                    this.options.range
                      ? 100 - this._state.percentage[1]
                      : this._state.percentage[1],
                  ]
                : [this._state.percentage[0], this._state.percentage[1]]),
              (this.handle1.style[this.stylePos] = t[0] + "%"),
              this.handle1.setAttribute("aria-valuenow", this._state.value[0]),
              (this.handle2.style[this.stylePos] = t[1] + "%"),
              this.handle2.setAttribute("aria-valuenow", this._state.value[1]),
              Array.isArray(this.options.ticks) &&
                this.options.ticks.length > 0)
            ) {
              var i =
                  "vertical" === this.options.orientation ? "height" : "width",
                e =
                  "vertical" === this.options.orientation
                    ? "marginTop"
                    : "marginLeft",
                s = this._state.size / (this.options.ticks.length - 1);
              if (this.tickLabelContainer) {
                var o = 0;
                if (0 === this.options.ticks_positions.length)
                  "vertical" !== this.options.orientation &&
                    (this.tickLabelContainer.style[e] = -s / 2 + "px"),
                    (o = this.tickLabelContainer.offsetHeight);
                else
                  for (
                    n = 0;
                    n < this.tickLabelContainer.childNodes.length;
                    n++
                  )
                    this.tickLabelContainer.childNodes[n].offsetHeight > o &&
                      (o = this.tickLabelContainer.childNodes[n].offsetHeight);
                "horizontal" === this.options.orientation &&
                  (this.sliderElem.style.marginBottom = o + "px");
              }
              for (var n = 0; n < this.options.ticks.length; n++) {
                var a =
                  this.options.ticks_positions[n] ||
                  this._toPercentage(this.options.ticks[n]);
                this.options.reversed && (a = 100 - a),
                  (this.ticks[n].style[this.stylePos] = a + "%"),
                  this._removeClass(this.ticks[n], "in-selection"),
                  this.options.range
                    ? a >= t[0] &&
                      a <= t[1] &&
                      this._addClass(this.ticks[n], "in-selection")
                    : "after" === this.options.selection && a >= t[0]
                    ? this._addClass(this.ticks[n], "in-selection")
                    : "before" === this.options.selection &&
                      a <= t[0] &&
                      this._addClass(this.ticks[n], "in-selection"),
                  this.tickLabels[n] &&
                    ((this.tickLabels[n].style[i] = s + "px"),
                    "vertical" !== this.options.orientation &&
                    void 0 !== this.options.ticks_positions[n]
                      ? ((this.tickLabels[n].style.position = "absolute"),
                        (this.tickLabels[n].style[this.stylePos] = a + "%"),
                        (this.tickLabels[n].style[e] = -s / 2 + "px"))
                      : "vertical" === this.options.orientation &&
                        ((this.tickLabels[n].style.marginLeft =
                          this.sliderElem.offsetWidth + "px"),
                        (this.tickLabelContainer.style.marginTop =
                          (this.sliderElem.offsetWidth / 2) * -1 + "px")));
              }
            }
            var h;
            if (this.options.range) {
              (h = this.options.formatter(this._state.value)),
                this._setText(this.tooltipInner, h),
                (this.tooltip.style[this.stylePos] = (t[1] + t[0]) / 2 + "%"),
                "vertical" === this.options.orientation
                  ? this._css(
                      this.tooltip,
                      "margin-top",
                      -this.tooltip.offsetHeight / 2 + "px"
                    )
                  : this._css(
                      this.tooltip,
                      "margin-left",
                      -this.tooltip.offsetWidth / 2 + "px"
                    ),
                "vertical" === this.options.orientation
                  ? this._css(
                      this.tooltip,
                      "margin-top",
                      -this.tooltip.offsetHeight / 2 + "px"
                    )
                  : this._css(
                      this.tooltip,
                      "margin-left",
                      -this.tooltip.offsetWidth / 2 + "px"
                    );
              var l = this.options.formatter(this._state.value[0]);
              this._setText(this.tooltipInner_min, l);
              var r = this.options.formatter(this._state.value[1]);
              this._setText(this.tooltipInner_max, r),
                (this.tooltip_min.style[this.stylePos] = t[0] + "%"),
                "vertical" === this.options.orientation
                  ? this._css(
                      this.tooltip_min,
                      "margin-top",
                      -this.tooltip_min.offsetHeight / 2 + "px"
                    )
                  : this._css(
                      this.tooltip_min,
                      "margin-left",
                      -this.tooltip_min.offsetWidth / 2 + "px"
                    ),
                (this.tooltip_max.style[this.stylePos] = t[1] + "%"),
                "vertical" === this.options.orientation
                  ? this._css(
                      this.tooltip_max,
                      "margin-top",
                      -this.tooltip_max.offsetHeight / 2 + "px"
                    )
                  : this._css(
                      this.tooltip_max,
                      "margin-left",
                      -this.tooltip_max.offsetWidth / 2 + "px"
                    );
            } else
              (h = this.options.formatter(this._state.value[0])),
                this._setText(this.tooltipInner, h),
                (this.tooltip.style[this.stylePos] = t[0] + "%"),
                "vertical" === this.options.orientation
                  ? this._css(
                      this.tooltip,
                      "margin-top",
                      -this.tooltip.offsetHeight / 2 + "px"
                    )
                  : this._css(
                      this.tooltip,
                      "margin-left",
                      -this.tooltip.offsetWidth / 2 + "px"
                    );
            if ("vertical" === this.options.orientation)
              (this.trackLow.style.top = "0"),
                (this.trackLow.style.height = Math.min(t[0], t[1]) + "%"),
                (this.trackSelection.style.top = Math.min(t[0], t[1]) + "%"),
                (this.trackSelection.style.height =
                  Math.abs(t[0] - t[1]) + "%"),
                (this.trackHigh.style.bottom = "0"),
                (this.trackHigh.style.height =
                  100 - Math.min(t[0], t[1]) - Math.abs(t[0] - t[1]) + "%");
            else {
              (this.trackLow.style.left = "0"),
                (this.trackLow.style.width = Math.min(t[0], t[1]) + "%"),
                (this.trackSelection.style.left = Math.min(t[0], t[1]) + "%"),
                (this.trackSelection.style.width = Math.abs(t[0] - t[1]) + "%"),
                (this.trackHigh.style.right = "0"),
                (this.trackHigh.style.width =
                  100 - Math.min(t[0], t[1]) - Math.abs(t[0] - t[1]) + "%");
              var p = this.tooltip_min.getBoundingClientRect(),
                d = this.tooltip_max.getBoundingClientRect();
              p.right > d.left
                ? (this._removeClass(this.tooltip_max, "top"),
                  this._addClass(this.tooltip_max, "bottom"),
                  (this.tooltip_max.style.top = "18px"))
                : (this._removeClass(this.tooltip_max, "bottom"),
                  this._addClass(this.tooltip_max, "top"),
                  (this.tooltip_max.style.top = this.tooltip_min.style.top));
            }
          },
          _removeProperty: function (t, i) {
            t.style.removeProperty
              ? t.style.removeProperty(i)
              : t.style.removeAttribute(i);
          },
          _mousedown: function (t) {
            if (!this._state.enabled) return !1;
            (this._state.offset = this._offset(this.sliderElem)),
              (this._state.size = this.sliderElem[this.sizePos]);
            var i = this._getPercentage(t);
            if (this.options.range) {
              var e = Math.abs(this._state.percentage[0] - i),
                s = Math.abs(this._state.percentage[1] - i);
              this._state.dragged = s > e ? 0 : 1;
            } else this._state.dragged = 0;
            (this._state.percentage[this._state.dragged] = i),
              this._layout(),
              this.touchCapable &&
                (document.removeEventListener("touchmove", this.mousemove, !1),
                document.removeEventListener("touchend", this.mouseup, !1)),
              this.mousemove &&
                document.removeEventListener("mousemove", this.mousemove, !1),
              this.mouseup &&
                document.removeEventListener("mouseup", this.mouseup, !1),
              (this.mousemove = this._mousemove.bind(this)),
              (this.mouseup = this._mouseup.bind(this)),
              this.touchCapable &&
                (document.addEventListener("touchmove", this.mousemove, !1),
                document.addEventListener("touchend", this.mouseup, !1)),
              document.addEventListener("mousemove", this.mousemove, !1),
              document.addEventListener("mouseup", this.mouseup, !1),
              (this._state.inDrag = !0);
            var o = this._calculateValue();
            return (
              this._trigger("slideStart", o),
              this._setDataVal(o),
              this.setValue(o, !1, !0),
              this._pauseEvent(t),
              this.options.focus &&
                this._triggerFocusOnHandle(this._state.dragged),
              !0
            );
          },
          _triggerFocusOnHandle: function (t) {
            0 === t && this.handle1.focus(), 1 === t && this.handle2.focus();
          },
          _keydown: function (t, i) {
            if (!this._state.enabled) return !1;
            var e;
            switch (i.keyCode) {
              case 37:
              case 40:
                e = -1;
                break;
              case 39:
              case 38:
                e = 1;
            }
            if (e) {
              if (this.options.natural_arrow_keys) {
                var s =
                    "vertical" === this.options.orientation &&
                    !this.options.reversed,
                  o =
                    "horizontal" === this.options.orientation &&
                    this.options.reversed;
                (s || o) && (e = -e);
              }
              var n = this._state.value[t] + e * this.options.step;
              return (
                this.options.range &&
                  (n = [
                    t ? this._state.value[0] : n,
                    t ? n : this._state.value[1],
                  ]),
                this._trigger("slideStart", n),
                this._setDataVal(n),
                this.setValue(n, !0, !0),
                this._setDataVal(n),
                this._trigger("slideStop", n),
                this._layout(),
                this._pauseEvent(i),
                !1
              );
            }
          },
          _pauseEvent: function (t) {
            t.stopPropagation && t.stopPropagation(),
              t.preventDefault && t.preventDefault(),
              (t.cancelBubble = !0),
              (t.returnValue = !1);
          },
          _mousemove: function (t) {
            if (!this._state.enabled) return !1;
            var i = this._getPercentage(t);
            this._adjustPercentageForRangeSliders(i),
              (this._state.percentage[this._state.dragged] = i),
              this._layout();
            var e = this._calculateValue(!0);
            return this.setValue(e, !0, !0), !1;
          },
          _adjustPercentageForRangeSliders: function (t) {
            if (this.options.range) {
              var i = this._getNumDigitsAfterDecimalPlace(t);
              i = i ? i - 1 : 0;
              var e = this._applyToFixedAndParseFloat(t, i);
              0 === this._state.dragged &&
              this._applyToFixedAndParseFloat(this._state.percentage[1], i) < e
                ? ((this._state.percentage[0] = this._state.percentage[1]),
                  (this._state.dragged = 1))
                : 1 === this._state.dragged &&
                  this._applyToFixedAndParseFloat(
                    this._state.percentage[0],
                    i
                  ) > e &&
                  ((this._state.percentage[1] = this._state.percentage[0]),
                  (this._state.dragged = 0));
            }
          },
          _mouseup: function () {
            if (!this._state.enabled) return !1;
            this.touchCapable &&
              (document.removeEventListener("touchmove", this.mousemove, !1),
              document.removeEventListener("touchend", this.mouseup, !1)),
              document.removeEventListener("mousemove", this.mousemove, !1),
              document.removeEventListener("mouseup", this.mouseup, !1),
              (this._state.inDrag = !1),
              this._state.over === !1 && this._hideTooltip();
            var t = this._calculateValue(!0);
            return (
              this._layout(),
              this._setDataVal(t),
              this._trigger("slideStop", t),
              !1
            );
          },
          _calculateValue: function (t) {
            var i;
            if (
              (this.options.range
                ? ((i = [this.options.min, this.options.max]),
                  0 !== this._state.percentage[0] &&
                    ((i[0] = this._toValue(this._state.percentage[0])),
                    (i[0] = this._applyPrecision(i[0]))),
                  100 !== this._state.percentage[1] &&
                    ((i[1] = this._toValue(this._state.percentage[1])),
                    (i[1] = this._applyPrecision(i[1]))))
                : ((i = this._toValue(this._state.percentage[0])),
                  (i = parseFloat(i)),
                  (i = this._applyPrecision(i))),
              t)
            ) {
              for (
                var e = [i, 1 / 0], s = 0;
                s < this.options.ticks.length;
                s++
              ) {
                var o = Math.abs(this.options.ticks[s] - i);
                o <= e[1] && (e = [this.options.ticks[s], o]);
              }
              if (e[1] <= this.options.ticks_snap_bounds) return e[0];
            }
            return i;
          },
          _applyPrecision: function (t) {
            var i =
              this.options.precision ||
              this._getNumDigitsAfterDecimalPlace(this.options.step);
            return this._applyToFixedAndParseFloat(t, i);
          },
          _getNumDigitsAfterDecimalPlace: function (t) {
            var i = ("" + t).match(/(?:\.(\d+))?(?:[eE]([+-]?\d+))?$/);
            return i
              ? Math.max(0, (i[1] ? i[1].length : 0) - (i[2] ? +i[2] : 0))
              : 0;
          },
          _applyToFixedAndParseFloat: function (t, i) {
            var e = t.toFixed(i);
            return parseFloat(e);
          },
          _getPercentage: function (t) {
            !this.touchCapable ||
              ("touchstart" !== t.type && "touchmove" !== t.type) ||
              (t = t.touches[0]);
            var i = t[this.mousePos],
              e = this._state.offset[this.stylePos],
              s = i - e,
              o = (s / this._state.size) * 100;
            return (
              (o =
                Math.round(o / this._state.percentage[2]) *
                this._state.percentage[2]),
              this.options.reversed && (o = 100 - o),
              Math.max(0, Math.min(100, o))
            );
          },
          _validateInputValue: function (t) {
            if ("number" == typeof t) return t;
            if (Array.isArray(t)) return this._validateArray(t), t;
            throw new Error(s.formatInvalidInputErrorMsg(t));
          },
          _validateArray: function (t) {
            for (var i = 0; i < t.length; i++) {
              var e = t[i];
              if ("number" != typeof e)
                throw new Error(s.formatInvalidInputErrorMsg(e));
            }
          },
          _setDataVal: function (t) {
            this.element.setAttribute("data-value", t),
              this.element.setAttribute("value", t),
              (this.element.value = t);
          },
          _trigger: function (i, e) {
            e = e || 0 === e ? e : void 0;
            var s = this.eventToCallbackMap[i];
            if (s && s.length)
              for (var o = 0; o < s.length; o++) {
                var n = s[o];
                n(e);
              }
            t && this._triggerJQueryEvent(i, e);
          },
          _triggerJQueryEvent: function (t, i) {
            var e = { type: t, value: i };
            this.$element.trigger(e), this.$sliderElem.trigger(e);
          },
          _unbindJQueryEventHandlers: function () {
            this.$element.off(), this.$sliderElem.off();
          },
          _setText: function (t, i) {
            "undefined" != typeof t.innerText
              ? (t.innerText = i)
              : "undefined" != typeof t.textContent && (t.textContent = i);
          },
          _removeClass: function (t, i) {
            for (
              var e = i.split(" "), s = t.className, o = 0;
              o < e.length;
              o++
            ) {
              var n = e[o],
                a = new RegExp("(?:\\s|^)" + n + "(?:\\s|$)");
              s = s.replace(a, " ");
            }
            t.className = s.trim();
          },
          _addClass: function (t, i) {
            for (
              var e = i.split(" "), s = t.className, o = 0;
              o < e.length;
              o++
            ) {
              var n = e[o],
                a = new RegExp("(?:\\s|^)" + n + "(?:\\s|$)"),
                h = a.test(s);
              h || (s += " " + n);
            }
            t.className = s.trim();
          },
          _offsetLeft: function (t) {
            return t.getBoundingClientRect().left;
          },
          _offsetTop: function (t) {
            for (
              var i = t.offsetTop;
              (t = t.offsetParent) && !isNaN(t.offsetTop);

            )
              i += t.offsetTop;
            return i;
          },
          _offset: function (t) {
            return { left: this._offsetLeft(t), top: this._offsetTop(t) };
          },
          _css: function (i, e, s) {
            if (t) t.style(i, e, s);
            else {
              var o = e
                .replace(/^-ms-/, "ms-")
                .replace(/-([\da-z])/gi, function (t, i) {
                  return i.toUpperCase();
                });
              i.style[o] = s;
            }
          },
          _toValue: function (t) {
            return this.options.scale.toValue.apply(this, [t]);
          },
          _toPercentage: function (t) {
            return this.options.scale.toPercentage.apply(this, [t]);
          },
          _setTooltipPosition: function () {
            var t = [this.tooltip, this.tooltip_min, this.tooltip_max];
            if ("vertical" === this.options.orientation) {
              var i = this.options.tooltip_position || "right",
                e = "left" === i ? "right" : "left";
              t.forEach(
                function (t) {
                  this._addClass(t, i), (t.style[e] = "100%");
                }.bind(this)
              );
            } else
              "bottom" === this.options.tooltip_position
                ? t.forEach(
                    function (t) {
                      this._addClass(t, "bottom"), (t.style.top = "22px");
                    }.bind(this)
                  )
                : t.forEach(
                    function (t) {
                      this._addClass(t, "top"),
                        (t.style.top = -this.tooltip.outerHeight - 14 + "px");
                    }.bind(this)
                  );
          },
        }),
        t)
      ) {
        var n = t.fn.slider ? "bootstrapSlider" : "slider";
        t.bridget(n, i);
      }
    })(t),
    i
  );
});