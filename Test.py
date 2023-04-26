def create_barchart(
    df,
    time_column,
    include_axis,
    colors,
    axis_only=False,
    percent=False,
    include_scale=False,
    required_months=None,
):
    df, df_transposed = clean_dataframe(
        df, time_column, required_months=required_months
    )

    if len(df.columns) == 2:
        df, swaps = swap(df, list(df.columns))
        df_transposed = df.transpose()
    else:
        swaps = [False for period in range(len(df.index))]

    chart = plt.figure(
        dpi=get_dpi(), figsize=get_figsize() if not axis_only else get_axisSize()
    ).add_axes([0, 0, 1, 1])

    row_nums = list(range(len(df.index)))
    bottom = [0 for n in range(len(df.index))]

    for x, col in enumerate(df.columns):
        if not df[col].isnull().values.all():
            for i, value in enumerate(df[col]):
                if swaps[i] is True:
                    bar_color = colors[::-1][x % len(colors)]
                else:
                    bar_color = colors[x % len(colors)]
                if pd.isnull(value):
                    # for placeholder period without values, such as CN & CEI for Q2 2021 and after
                    chart.bar(row_nums[i], 0, width=0.5, alpha=0)
                else:
                    chart.bar(
                        row_nums[i], value, width=0.5, bottom=bottom[i], color=bar_color
                    )

            bottom = np.add(bottom, list(df[col]))

    # Make sure that percentage plots scale correctly, from 0-100%
    if percent:
        chart.set_ylim(0, 100)

    # Labelling logic
    for i, period in enumerate(df.index):
        r = len(df.index)
        # the bars in the chart
        rects = chart.patches[i::r]
        if not df_transposed[period].isnull().values.all():

            if percent:
                labels = [format_number(v) for v in list(df_transposed[period])]
                labels = [str(label) + "%" for label in labels]
            else:
                labels = [format_number_to_10s(v) for v in list(df_transposed[period])]

            height = 0
            # the loop is mainly for the benefit of the restore stacked bars
            # the height is innitiated to 0 for each bar, the label is added to the top of the bar height
            for enum, rect, label in zip(list(range(len(rects))), rects, labels):
                height = height + rect.get_height()

                if str(label) not in ["nan", "0", "0.0", "0.0%"]:
                    # 0% of offset
                    vertical_offset = percent_to_relative_value_of_range(
                        chart.get_ylim(), 0
                    )
                    if swaps[i]:
                        label_color = colors[::-1][enum % len(colors)]
                    else:
                        label_color = colors[enum % len(colors)]
                    if enum > 0:
                        # for the label of the second stacked bar
                        this_box_height_as_percent_of_axis = (
                            height / chart.get_ylim()[1]
                        )
                        prev_box_height_as_percent_of_axis = (
                            rects[enum - 1].get_height() / chart.get_ylim()[1]
                        )

                        vertical_difference = (
                            this_box_height_as_percent_of_axis
                            - prev_box_height_as_percent_of_axis
                        )

                        # 0.1 or 10% of the chart height that can accommodate the text label on the bars
                        # we may need to adjust this fraction if necessary
                        label_collision_threshold = get_label_collision_threshold()
                        if abs(vertical_difference) < label_collision_threshold:
                            # how much do we need to move so that the text labels do not collide
                            # just enough to fit the lower text label
                            vertical_offset = percent_to_relative_value_of_range(
                                chart.get_ylim(),
                                label_collision_threshold - vertical_difference,
                            )

                    chart.text(
                        round(rect.get_x(), 10) + round(rect.get_width() / 2, 10),
                        height + vertical_offset,
                        label,
                        ha="center",
                        va="bottom",
                        fontsize=get_fontsize_barchart(),
                        # fontweight="bold",
                        color=label_color,
                    )

    if include_scale:
        scale_color = (0, 0, 0, 1)  # just black
        # plot the first no-color bar using the scale
        # when we do that , we have to shift the header as well
        if percent:
            high_bound = 100
            high_bound_label = "100%"
            low_bound_label = "0%"
        else:
            # keep only two significant digits
            ylim = max(chart.get_ylim())
            significant_digits = 2
            high_bound = round(
                ylim, significant_digits - int(math.floor(math.log10(abs(ylim)))) - 1
            )
            high_bound_label = format_number(high_bound)
            low_bound_label = "0"

        chart.bar(-1, high_bound, width=0.01, bottom=0, color=chart.get_facecolor())

        rect = chart.patches[-1]
        chart.text(
            round(rect.get_x(), 10) + round(rect.get_width() / 2, 10),
            0,
            low_bound_label,
            ha="center",
            va="bottom",
            fontsize=get_fontsize_barchart(),
            # fontweight="bold",
            color=scale_color,
        )

        chart.text(
            round(rect.get_x(), 10) + round(rect.get_width() / 2, 10),
            rect.get_height(),
            high_bound_label,
            ha="center",
            va="bottom",
            fontsize=get_fontsize_barchart(),
            # fontweight="bold",
            color=scale_color,
        )

    return chart


